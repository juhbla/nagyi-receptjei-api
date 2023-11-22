using Microsoft.EntityFrameworkCore;
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
        return _context.Recipes
            .Include(recipe => recipe.Ingredients)
            .Include(recipe => recipe.Comments)
            .ThenInclude(comment => comment.User)
            .ToList();
    }

    public Recipe Add(Recipe recipe)
    {
        var newRecipe = _context.Recipes.Add(recipe).Entity;
        _context.SaveChanges();
        return newRecipe;
    }
}
