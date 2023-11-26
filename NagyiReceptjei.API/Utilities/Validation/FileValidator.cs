using NagyiReceptjei.API.Utilities.Exceptions;

namespace NagyiReceptjei.API.Utilities.Validation;

public class FileValidator : IFileValidator
{
    private readonly string[] _acceptedExtensions =
    {
        FileConstants.Jpg,
        FileConstants.Jpeg,
        FileConstants.Png,
        FileConstants.Bmp,
    };

    public void Validate(IFormFile file)
    {
        if (file == null)
        {
            throw new NullFileException();
        }

        if (file.Length == 0)
        {
            throw new EmptyFileException();
        }

        if (file.Length > FileConstants.MaxFileBytes)
        {
            throw new MaximumFileSizeExceededException();
        }

        if (_acceptedExtensions.All(extension => extension != Path.GetExtension(file.FileName).ToLower()))
        {
            throw new InvalidFileTypeException();
        }
    }
}
