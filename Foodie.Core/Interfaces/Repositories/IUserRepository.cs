using Foodie.Core.Models;

namespace Foodie.Core.Interfaces.Repositories;

public interface IUserRepository
{
    public Task<int> CreateUser(string name, string email, string passwordHash);

    public Task<User?> GetUser(int userId);

}
