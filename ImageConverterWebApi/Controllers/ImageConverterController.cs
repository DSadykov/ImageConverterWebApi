using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImageConverterWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageConverterController : ControllerBase
{

    private readonly ILogger<ImageConverterController> _logger;
    private readonly ImageConverterService _imageConverter;
    public ImageConverterController(ILogger<ImageConverterController> logger, ImageConverterService imageConverter)
    {
        _logger = logger;
        _imageConverter = imageConverter;
    }

    [HttpPost(Name = "ConvertImage")]
    public async Task<IFormFile> Post([FromForm] InputImageModel imageModel)
    {
        _logger.LogInformation("Came {fileName} to extension {toExtension}", imageModel.ImageFile.FileName, imageModel.ExtensionTo);
        return await Task.Run((() => _imageConverter.ConvertImage(imageModel)));
    }
}
