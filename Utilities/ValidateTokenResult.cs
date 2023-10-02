using System.IdentityModel.Tokens.Jwt;

namespace CVLookup_WebAPI.Utilities
{
	public class VerifyTokenResult
	{
		public bool IsExpired { get; set; }
		public bool IsValid { get; set; }
		public JwtSecurityToken	Token { get; set; }
	}
}
