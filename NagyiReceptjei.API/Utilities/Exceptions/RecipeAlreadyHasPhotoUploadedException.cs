namespace NagyiReceptjei.API.Utilities.Exceptions;

public sealed class RecipeAlreadyHasPhotoUploadedException : Exception
{
    public RecipeAlreadyHasPhotoUploadedException(int recipeId)
        : base($"Recipe with id: {recipeId} already has photo uploaded.")
    {
    }
}
