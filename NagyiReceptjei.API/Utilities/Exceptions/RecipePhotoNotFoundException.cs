namespace NagyiReceptjei.API.Utilities.Exceptions;

public sealed class RecipePhotoNotFoundException : Exception
{
    public RecipePhotoNotFoundException(string fileName)
        : base($"Photo of recipe not found with file name: {fileName}.")
    {
    }
}
