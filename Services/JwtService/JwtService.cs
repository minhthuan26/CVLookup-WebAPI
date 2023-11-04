using CVLookup_WebAPI.Utilities;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Specialized;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CVLookup_WebAPI.Services.JwtService
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GenerateToken(string key, ListDictionary data, DateTime expires)
        {
            try
            {
                var signingCredential = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    SecurityAlgorithms.HmacSha512Signature
                );
                var claims = new List<Claim>();
                if (data.Count > 0)
                {
                    foreach (DictionaryEntry entry in data)
                    {
                        claims.Add(new(entry.Key.ToString(), entry.Value.ToString()));
                    }
                }

                var tokenDescript = new JwtSecurityToken(
                    claims: claims,
                    expires: expires,
                    signingCredentials: signingCredential
                );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenDescript);
                if (token == null)
                {
                    throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình ghi token");
                }
                return token;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ExceptionModel(500, "Thất bại. Độ dài khoá không hợp lệ. " + e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionModel(500, e.Message);
            }

        }

        public async Task<VerifyTokenResult> VerifyToken(string token, string key)
        {
            try
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKeys = new List<SecurityKey> { signingKey },
                    ValidateLifetime = true
                };


                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                var jwt = (JwtSecurityToken)validatedToken;

                return new VerifyTokenResult
                {
                    IsExpired = false,
                    IsValid = true,
                    Token = jwt
                };
            }
            catch (SecurityTokenExpiredException)
            {
                return new VerifyTokenResult
                {
                    IsExpired = true,
                    IsValid = true,
                    Token = null
                };
            }
            catch (SecurityTokenValidationException)
            {
                return new VerifyTokenResult
                {
                    IsExpired = false,
                    IsValid = false,
                    Token = null
                };
            }

            catch (ArgumentException)
            {
                return new VerifyTokenResult
                {
                    IsExpired = false,
                    IsValid = false,
                    Token = null
                };
            }
        }

        public async Task<ListDictionary> GetTokenClaims(VerifyTokenResult result)
        {
            try
            {
                if (!result.IsValid)
                {
                    throw new ExceptionModel(400, "Thất bại. Token không hợp lệ");
                }

                if (result.IsExpired)
                {
                    throw new ExceptionModel(403, "Thất bại. Token đã hết hạn");
                }

                ListDictionary claims = new();

                foreach (Claim claim in result.Token.Claims)
                {
                    claims.Add(claim.Type, claim.Value);
                }

                return claims;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

        public string GetSecretKey()
        {
            return _configuration.GetValue<string>("JwtConfig:SECRET_KEY");
        }

        public string GetRefreshKey()
        {
            return _configuration.GetValue<string>("JwtConfig:REFRESH_KEY");
        }
        public string GetMailKey()
        {
            return _configuration.GetValue<string>("MailConfig:MAIL_KEY");
        }
    }
}
