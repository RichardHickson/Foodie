using Foodie.Core.Interfaces.Repositories;

namespace Foodie.Api.Routes.User;

public class GetUserHandler
{
    public static async Task<IResult> Get(int userId, IUserRepository userRepository)
    {
        var user = await userRepository.GetUser(userId);
        if (user is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(user);
    }
}
