namespace RideIt.Services.Abstraction;

public interface IFileSystemService
{
    string Create(IFormFile file,Guid userId);
    bool DeleteFile(string filePath);
}