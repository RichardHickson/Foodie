using Dapper;
using Foodie.Core.Interfaces.Repositories;
using System.Data.Common;

namespace Foodie.Core.Repositories;

public class TokenRepository(DbConnection connection) : BaseRepository(connection), ITokenRepository
{
    async Task<string> ITokenRepository.CreateAccessToken(string accessToken, int userId, DateTime expiresAt)
    {
        await Connection.ExecuteAsync(@"
            INSERT INTO AccessToken(Token, UserId, ExpiresAt)
            VALUES (@accessToken, @userId, @expiresAt);
        ", new { accessToken, userId, expiresAt });

        return accessToken;
    }

    async Task<string> ITokenRepository.CreateRefreshToken(string refreshToken, int userId, DateTime expiresAt)
    {
        await Connection.ExecuteAsync(@"
            INSERT INTO AccessToken(Token, UserId, ExpiresAt)
            VALUES (@refreshToken, @userId, @expiresAt);
        ", new { refreshToken, userId, expiresAt });

        return refreshToken;
    }

    async Task<int> ITokenRepository.GetUserIdFromAccessToken(int accessToken)
    {
        var userId = await Connection.ExecuteScalarAsync<int>(@"
            SELECT UserId FROM AccessToken
            WHERE AccessToken = @accessToken
        ", new { accessToken });
        return userId;
    }

    async Task<int> ITokenRepository.GetUserIdFromRefreshToken(int refreshToken)
    {
        var userId = await Connection.ExecuteScalarAsync<int>(@"
            SELECT UserId FROM RefreshToken
            WHERE RefreshToken = @refreshToken
        ", new { refreshToken });
        return userId;
    }

    async Task ITokenRepository.RevokeRefreshToken(int refreshToken)
    {
       await Connection.ExecuteAsync(@"
            DELETE FROM RefreshToken
            WHERE RefreshToken = @refreshToken
        ", new { refreshToken });
    }

    async Task ITokenRepository.RevokeUserTokens(int userId)
    {
        await Connection.ExecuteAsync(@"
            DELETE FROM RefreshToken 
            WHERE UserId = @userId
        ", new { userId });
    }
}
