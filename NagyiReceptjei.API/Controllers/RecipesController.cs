using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NagyiReceptjei.API.Controllers.Resources.Requests;
using NagyiReceptjei.API.Controllers.Resources.Responses;
using NagyiReceptjei.API.Models;
using NagyiReceptjei.API.Repositories;

namespace NagyiReceptjei.API.Controllers;

[ApiController]
[EnableCors("DefaultCorsPolicy")]
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
    public IResult CreateRecipe([FromBody] CreateRecipeRequest request)
    {
        var recipe = _mapper.Map<CreateRecipeRequest, Recipe>(request);
        var newRecipe = _recipeRepository.Add(recipe);
        var recipeResponse = _mapper.Map<Recipe, GetRecipeResponse>(newRecipe);
        return Results.Ok(recipeResponse);
    }
}
