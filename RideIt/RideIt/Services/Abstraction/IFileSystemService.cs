namespace RideIt.Services.Abstraction;

public interface IFileSystemService
{
    string Create(IFormFile file, string folderName,int? userId);
    bool DeleteFile(string filePath);
}