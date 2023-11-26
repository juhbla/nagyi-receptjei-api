namespace NagyiReceptjei.API.Utilities;

public abstract class PhotoService<TFile, TPhoto>
{
    public abstract Task<byte[]> GetPhoto(string fileName);
    public abstract Task<TPhoto> UploadPhoto(string contentRootPath, TFile file, int id);
    public abstract string GenerateContentType(string fileName);
}
