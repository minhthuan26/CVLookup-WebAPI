using CVLookup_WebAPI.Utilities;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;

namespace CVLookup_WebAPI.Services.JwtService
{
    public interface IJwtService
    {
        public Task<string> GenerateToken(string key, ListDictionary data, DateTime expires);
        public Task<VerifyTokenResult> VerifyToken(string token, string key);
        public Task<ListDictionary> GetTokenClaims(VerifyTokenResult result);
        public string GetSecretKey();
        public string GetRefreshKey();
        public string GetMailKey();
    }
}
