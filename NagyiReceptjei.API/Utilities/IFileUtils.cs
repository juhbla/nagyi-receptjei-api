namespace NagyiReceptjei.API.Utilities;

public interface IFileUtils
{
    Task<byte[]> ReadAllBytesAsync(string path);
    string GenerateContentType(string fileName);
    string GetUploadsDirectory(string contentRootPath, string uploadsDirectoryRootPath);
    void CreateUploadsDirectoryIfNotExists(string uploadsDirectoryPath);
    Task<string> Store(IFormFile file, string uploadsDirectoryPath);
}
