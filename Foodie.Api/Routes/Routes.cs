using Foodie.Api.Routes.Ingredient;

namespace Foodie.Api.Routes;

public static class Routes
{
    public static void AddRoutes(this WebApplication app)
    {
        var ingredientGroup = app.MapGroup("/Ingredient");

        ingredientGroup.MapGet("/{ingredientId:int}", GetIngredientHandler.Get);
        ingredientGroup.MapPost("/Create", CreateIngredientHandler.Post);
    }
}
