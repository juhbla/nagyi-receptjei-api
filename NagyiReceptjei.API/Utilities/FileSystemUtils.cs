using NagyiReceptjei.API.Utilities.Validation;

namespace NagyiReceptjei.API.Utilities;

public class FileSystemUtils : IFileUtils
{
    public async Task<byte[]> ReadAllBytesAsync(string path)
    {
        return await File.ReadAllBytesAsync(path);
    }

    public string GenerateContentType(string fileName)
    {
        return $"{FileConstants.Image}/{Path.GetExtension(fileName).Split(".")[1]}";
    }

    public string GetUploadsDirectory(string contentRootPath, string uploadsDirectoryRootPath)
    {
        return Path.Combine(contentRootPath, uploadsDirectoryRootPath);
    }

    public void CreateUploadsDirectoryIfNotExists(string uploadsDirectoryPath)
    {
        if (!Directory.Exists(uploadsDirectoryPath))
        {
            Directory.CreateDirectory(uploadsDirectoryPath);
        }
    }

    public async Task<string> Store(IFormFile file, string uploadsDirectoryPath)
    {
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadsDirectoryPath, fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return fileName;
    }
}
