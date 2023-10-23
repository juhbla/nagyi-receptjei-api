using Microsoft.AspNetCore.Mvc;
using NagyiReceptjei.API.Models;
using NagyiReceptjei.API.Repositories;

namespace NagyiReceptjei.API.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class RecipesController
{
    private readonly RecipeRepository _recipeRepository;

    public RecipesController(RecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    // GET: api/recipes
    [HttpGet]
    public IResult GetRecipes()
    {
        return Results.Ok(_recipeRepository.GetRecipes());
    }

    // POST: api/recipes
    [HttpPost]
    public IResult CreateRecipe([FromBody] Recipe request)
    {
        return null;
    }

    // PUT: api/recipes/id
    [HttpPut("{id:int}")]
    public IResult UpdateRecipe(int id, [FromBody] Recipe request)
    {
        return null;
    }

    // DELETE: api/recipes/1
    [HttpDelete("{id:int}")]
    public IResult DeleteRecipe(int id)
    {
        return null;
    }
}
