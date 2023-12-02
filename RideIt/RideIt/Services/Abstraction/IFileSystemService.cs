namespace RideIt.Services.Abstraction;

public interface IFileSystemService
{
    string GetImageUrl(IFormFile file);
}