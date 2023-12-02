using RideIt.Services.Abstraction;

namespace RideIt.Services;
using Microsoft.AspNetCore.Hosting;

public class FileSystemService : IFileSystemService
{
    public const string StoragePath = "Pics";
    public string GetImageUrl(IFormFile file)
    {
        var path = Path.Combine(StoragePath, $"{Guid.NewGuid()}");

        using var stream = new FileStream(path, FileMode.Create);
        file.CopyTo(stream);
        
        return path;
    }
}