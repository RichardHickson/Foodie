using Foodie.Api.Routes.Ingredient;
using Foodie.Api.Routes.User;

namespace Foodie.Api.Routes;

public static class Routes
{
    public static void AddRoutes(this WebApplication app)
    {
        var ingredientGroup = app.MapGroup("/Ingredient");

        ingredientGroup.MapGet("/{ingredientId:int}", GetIngredientHandler.Get);
        ingredientGroup.MapPost("/Create", CreateIngredientHandler.Post);

        var userGroup = app.MapGroup("/User");

        userGroup.MapGet("/{userId:int}", GetUserHandler.Get);
        userGroup.MapPost("/Create", CreateUserHandler.Post);
    }
}
