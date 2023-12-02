using Carter;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace RideIt.Features.Images;

public class GetImageEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/images/{filename}", Task<Results<FileStreamHttpResult, NotFound>>(string filename,[FromServices] IWebHostEnvironment env) =>
                {
                    var imagePath = Path.Combine(env.ContentRootPath, "Pics", filename);

                    if (!File.Exists(imagePath))
                    {
                        return Task.FromResult<Results<FileStreamHttpResult, NotFound>>(TypedResults.NotFound());
                    }

                    var fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
        
                    string imageFileExtension = Path.GetExtension(imagePath);

                    return Task.FromResult<Results<FileStreamHttpResult, NotFound>>(TypedResults.File(fileStream, GetImageMimeTypeFromImageFileExtension(imageFileExtension)));
                    
                })
            .WithName("GetImage");
    }
    
    private string GetImageMimeTypeFromImageFileExtension(string extension)
    {
        string mimetype = extension switch
        {
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".bmp" => "image/bmp",
            ".tiff" => "image/tiff",
            ".wmf" => "image/wmf",
            ".jp2" => "image/jp2",
            ".svg" => "image/svg+xml",
            _ => "application/octet-stream",
        };
        return mimetype;
    }
}