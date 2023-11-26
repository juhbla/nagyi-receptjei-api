namespace NagyiReceptjei.API.Utilities.Exceptions;

public class RecipeNotFoundException : Exception
{
    public RecipeNotFoundException(int recipeId)
        : base($"Recipe not found with id: {recipeId}.")
    {
    }
}
