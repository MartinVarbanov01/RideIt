using RideIt.Services.Abstraction;

namespace RideIt.Services;
using Microsoft.AspNetCore.Hosting;

public class FileSystemService : IFileSystemService
{
    private readonly IHostingEnvironment _appEnvironmen;
    public FileSystemService(IHostingEnvironment appEnvironmen)
    {
        _appEnvironmen = appEnvironmen;
    }
    public string Create(IFormFile file, Guid entityId)
    {
        var folder = entityId.ToString();

        var path = $"/Files/{folder}";

        string pathWithEnviroment;
        
        if (file != null)
        {
                path = path + $"/{folder}/";

                pathWithEnviroment = _appEnvironmen.WebRootPath + path;

                if (!Directory.Exists(pathWithEnviroment))
                {
                    Directory.CreateDirectory(pathWithEnviroment);
                }

                path = path + $"/imageForUserId{folder}.jpg";

            pathWithEnviroment = _appEnvironmen.WebRootPath + path;
            using (var stream = new FileStream(pathWithEnviroment, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
        return path;
    }

    public bool DeleteFile(string filePath)
    {
        throw new NotImplementedException();
    }
}