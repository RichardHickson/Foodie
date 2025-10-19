using Foodie.Core.Interfaces.Repositories;

namespace Foodie.Api.Routes.Ingredient;

public static class CreateIngredientHandler
{
    public record CreateIngredientDTO(string Name, int Calories, int Protein, int Sugar, string Unit);
    public static async Task<IResult> Post(CreateIngredientDTO data, IIngredientRepository ingredientRepository)
    {
        var ingredientId = await ingredientRepository.CreateIngredient(data.Name, data.Calories, data.Protein, data.Sugar, data.Unit);

        return Results.Ok(ingredientId);
    }
}
