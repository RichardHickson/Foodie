using Dapper;
using Foodie.Core.Interfaces.Repositories;
using Foodie.Core.Models;
using System.Data.Common;

namespace Foodie.Core.Repositories;

public class IngredientRepository(DbConnection connection) : BaseRepository(connection), IIngredientRepository
{
    async Task<int> IIngredientRepository.CreateIngredient(string name, int calories, int protein, int sugar, string unit)
    {
        var ingredientId = await Connection.ExecuteScalarAsync<int>(@"
            INSERT INTO Ingredient(Name, Calories, Protein, Sugar, Unit)
            VALUES (@name, @calories, @protein, @sugar, @unit)
            RETURNING IngredientId;
        ", new { name, calories, protein, sugar, unit });

        return ingredientId;
    }

    async Task<Ingredient?> IIngredientRepository.GetIngredient(int ingredientId)
    {
        var ingredient = await Connection.QueryFirstOrDefaultAsync<Ingredient>(@"
            SELECT Name, Calories, Protein, Sugar, Unit FROM Ingredient
            WHERE IngredientId = @ingredientId;
        ", new { ingredientId });

        return ingredient;
    }
}
