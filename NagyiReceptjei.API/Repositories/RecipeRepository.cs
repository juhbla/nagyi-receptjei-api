using NagyiReceptjei.API.Models;

namespace NagyiReceptjei.API.Repositories;

public class RecipeRepository
{
    private readonly ApplicationDbContext _context;

    public RecipeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Recipe> GetRecipes()
    {
        return _context.Recipes.ToList();
    }

    private Recipe GetRecipe(int id)
    {
        return _context.Recipes.SingleOrDefault(recipe => recipe.Id == id);
    }

    public Recipe Add(Recipe recipe)
    {
        var newRecipe = _context.Recipes.Add(recipe).Entity;
        _context.SaveChanges();
        return newRecipe;
    }

    public Recipe DeleteRecipe(int id)
    {
        var recipeToDelete = GetRecipe(id);
        var removedRecipe = _context.Recipes.Remove(recipeToDelete).Entity;
        _context.SaveChanges();
        return removedRecipe;
    }
}
