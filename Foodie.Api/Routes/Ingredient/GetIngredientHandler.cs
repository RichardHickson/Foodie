using Foodie.Core.Interfaces.Repositories;

namespace Foodie.Api.Routes.Ingredient;

public static class GetIngredientHandler
{
    public static async Task<IResult> Get(int ingredientId, IIngredientRepository ingredientRepository) 
    {
        var ingredient = await ingredientRepository.GetIngredient(ingredientId);
        if (ingredient is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(ingredient);
    }
}
