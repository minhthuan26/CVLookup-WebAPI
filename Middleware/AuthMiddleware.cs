using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Services.JwtService;
using CVLookup_WebAPI.Services.RoleService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;


namespace CVLookup_WebAPI.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJwtService _jwtService;

        public AuthMiddleware(RequestDelegate next, IJwtService jwtService)
        {
            _next = next;
            _jwtService = jwtService;
        }

        public async Task Invoke(HttpContext context, AppDBContext dbContext)
        {
            try
            {
                string bearerToken = context.Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(bearerToken) || !bearerToken.StartsWith("Bearer"))
                {
                    throw new ExceptionModel(401, "Thất bại. Yêu cầu đăng nhập");
                }

                string accessToken = bearerToken.Split(" ")[1];

                //Lấy roll của controller
                var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
                var attribute = endpoint?.Metadata.GetMetadata<AuthorizationAttribute>();

                //Lấy roll của access token
                VerifyTokenResult verifyResult = await _jwtService.VerifyToken(accessToken, _jwtService.GetSecretKey());
                ListDictionary claims = await _jwtService.GetTokenClaims(verifyResult);
                if (claims == null)
                {
                    throw new ExceptionModel(401, "Thất bại. Token không hợp lệ");
                }
                string roleId = (string)claims["roleId"];
                Role roleInToken = await dbContext.Role.Where(prop => prop.Id == roleId).FirstOrDefaultAsync();
                if (roleInToken == null)
                {
                    throw new ExceptionModel(401, "Thất bại. Bạn không có quyền truy cập");
                }

                if (!attribute.GetRole().Contains(roleInToken.RoleName))
                {
                    throw new ExceptionModel(401, "Thất bại. Bạn không có quyền truy cập");
                }

                await _next(context);
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }

    }
}
