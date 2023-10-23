using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NagyiReceptjei.API.Models;
using NagyiReceptjei.API.Repositories;
using NagyiReceptjei.API.Resources;

namespace NagyiReceptjei.API.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class RecipesController
{
    private readonly RecipeRepository _recipeRepository;
    private readonly IMapper _mapper;

    public RecipesController(
        RecipeRepository recipeRepository,
        IMapper mapper
    )
    {
        _recipeRepository = recipeRepository;
        _mapper = mapper;
    }

    // GET: api/recipes
    [HttpGet]
    public IResult GetRecipes()
    {
        var recipes = _recipeRepository.GetRecipes();
        var recipesResponses = _mapper.Map<IEnumerable<Recipe>, IEnumerable<GetRecipeResponse>>(recipes);
        return Results.Ok(recipesResponses);
    }

    // POST: api/recipes
    [HttpPost]
    public IResult CreateRecipe([FromBody] Recipe request)
    {
        return Results.Ok(_recipeRepository.Add(request));
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
        return Results.Ok(_recipeRepository.DeleteRecipe(id));
    }
}
