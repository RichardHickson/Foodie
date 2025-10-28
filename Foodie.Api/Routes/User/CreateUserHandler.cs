using Foodie.Core.Interfaces.Repositories;

namespace Foodie.Api.Routes.User;

public class CreateUserHandler
{
    public record CreateUserDTO(string Name, string Email, string Password);
    public static async Task<IResult> Post(CreateUserDTO data, IUserRepository userRepository)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(data.Password);
        var userId = await userRepository.CreateUser(data.Name, data.Email, passwordHash);

        return Results.Ok(userId);
    }
}
