using NagyiReceptjei.API.Models;
using NagyiReceptjei.API.Repositories;
using NagyiReceptjei.API.Utilities.Exceptions;
using NagyiReceptjei.API.Utilities.Validation;

namespace NagyiReceptjei.API.Utilities;

public class RecipePhotoService : PhotoService<IFormFile, Photo>
{
    private readonly RecipeRepository _recipeRepository;
    private readonly ApplicationDbContext _context;
    private readonly IFileUtils _fileUtils;
    private readonly IFileValidator _fileValidator;

    public RecipePhotoService(
        RecipeRepository recipeRepository,
        ApplicationDbContext context,
        IFileUtils fileUtils,
        IFileValidator fileValidator
    )
    {
        _recipeRepository = recipeRepository;
        _context = context;
        _fileUtils = fileUtils;
        _fileValidator = fileValidator;
    }

    public override async Task<byte[]> GetPhoto(string fileName)
    {
        byte[] recipePhoto;

        try
        {
            recipePhoto = await _fileUtils.ReadAllBytesAsync(
                $"{FileConstants.RecipePhotoUploadsDirectoryPath}/{fileName}"
            );
        }
        catch
        {
            throw new RecipePhotoNotFoundException(fileName);
        }

        return recipePhoto;
    }

    public override async Task<Photo> UploadPhoto(string contentRootPath, IFormFile file, int id)
    {
        _fileValidator.Validate(file);

        var recipe = _recipeRepository.GetRecipe(id);

        if (recipe is null)
        {
            throw new RecipeNotFoundException(id);
        }

        if (recipe.Photo is not null)
        {
            throw new RecipeAlreadyHasPhotoUploadedException(id);
        }

        var uploadsDirectoryPath = _fileUtils.GetUploadsDirectory(
            contentRootPath,
            FileConstants.RecipePhotoUploadsDirectoryPath
        );

        _fileUtils.CreateUploadsDirectoryIfNotExists(uploadsDirectoryPath);

        var fileName = await _fileUtils.Store(file, uploadsDirectoryPath);
        recipe.Photo = new Photo { FileName = fileName };

        await _context.SaveChangesAsync();

        return recipe.Photo;
    }

    public override string GenerateContentType(string fileName)
    {
        return _fileUtils.GenerateContentType(fileName);
    }
}
