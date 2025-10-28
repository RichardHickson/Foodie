using Dapper;
using Foodie.Core.Interfaces.Repositories;
using Foodie.Core.Models;
using System.Data.Common;

namespace Foodie.Core.Repositories;

public class UserRepository(DbConnection connection) : BaseRepository(connection), IUserRepository
{
    async Task<int> IUserRepository.CreateUser(string name, string email, string passwordHash)
    {
        var userId = await Connection.ExecuteScalarAsync<int>(@"
            INSERT INTO User(Name, Email, PasswordHash)
            VALUES (@name, @email, @passwordHash)
            RETURNING UserId;
        ", new { name, email, passwordHash });

        return userId;
    }

    async Task<User?> IUserRepository.GetUser(int userId)
    {
        var user = await Connection.ExecuteScalarAsync<User>(@"
            SELECT UserId, Name, Email FROM User
            WHERE UserId = @userId;
        ", new { userId });
        return user;
    }
}
