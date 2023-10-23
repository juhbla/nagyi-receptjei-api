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
}
