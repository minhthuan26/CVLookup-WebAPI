using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.RefreshTokenService
{
    public interface ITokenService
    {
        public Task<Token> AddRefreshToken(TokenVM tokenVM);
        public Task<Token> EditRefreshToken(TokenVM tokenVM );
        public Task<Token> DeleteRefreshToken(string userId, string accountId);
        public Task<Token> DeleteRefreshToken(string token);
        public Task<Token> GetTokenById(string userId, string accountId);
        public Task<Token> GetTokenByValue(string token);
    }
}
