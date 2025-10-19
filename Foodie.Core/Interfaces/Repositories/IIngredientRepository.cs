using Foodie.Core.Models;

namespace Foodie.Core.Interfaces.Repositories;

public interface IIngredientRepository
{
    public Task<Ingredient?> GetIngredient(int ingredientId);
    public Task<int> CreateIngredient(string name, int calories, int protein, int sugar, string unit);
}
