/*namespace RideIt.Services;
using Microsoft.AspNetCore.Hosting;

public class FileSystemService
{
    private readonly IHostingEnvironment _appEnvironmen;

    public const string animeImages = "AnimeImages";
    public const string userImages = "UserImages";
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
                path = path + $"/{userFolder}/";

                pathWithEnviroment = _appEnvironmen.WebRootPath + path;

                if (!Directory.Exists(pathWithEnviroment))
                {
                    Directory.CreateDirectory(pathWithEnviroment);
                }

                path = path + $"/imageForUserId{userFolder}.jpg";

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
        var defaultPath = $"/Files/{userImages}/UserDefaultImage/DefaultImage.jpg";
        try
        {
            if (filePath == defaultPath) return true;
            File.Delete(_appEnvironmen.WebRootPath + filePath);
        }
        catch
        {

            return false;
        }

        return true;
    }
}*/