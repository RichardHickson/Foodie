using Foodie.Core.Models;

namespace Foodie.Core.Interfaces.Repositories;

public interface ITokenRepository
{
    public Task<string> CreateAccessToken(string accessToken, int userId, DateTime expiresAt);

    public Task<string> CreateRefreshToken(string refreshToken, int userId, DateTime expiresAt);

    public Task<int> GetUserIdFromRefreshToken(int refreshToken);

    public Task<int> GetUserIdFromAccessToken(int accessToken);

    public Task RevokeRefreshToken(int refreshToken);
    public Task RevokeUserTokens(int userId);
}
