using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.RefreshTokenService
{
    public interface IRefreshTokenService
    {
        public Task<RefreshToken> AddRToken(RefreshToken r);
        public Task<RefreshToken> EditRToken(string userId, string accountId, RefreshToken refreshToken );
        public Task<RefreshToken> DeleteRToken(string id );
        public Task<RefreshToken> GetToken();
    }
}
