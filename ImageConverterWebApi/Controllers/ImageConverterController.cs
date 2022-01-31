using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services;
using ImageConverterWebApi.Services.DB;
using Microsoft.AspNetCore.Mvc;

namespace ImageConverterWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageConverterController : ControllerBase
{

    private readonly ILogger<ImageConverterController> _logger;
    private readonly ImageConverterService _imageConverter;
    private readonly UsersDBContext _dBContext;

    public ImageConverterController(ILogger<ImageConverterController> logger, ImageConverterService imageConverter, UsersDBContext dBContext)
    {
        _logger = logger;
        _imageConverter = imageConverter;
        _dBContext = dBContext;
    }
    [HttpPost(Name = "ConvertImage")]
    public async Task<ActionResult> Post([FromForm] InputImageModel imageModel)
    {
        _logger.LogInformation("Came {fileName} to extension {toExtension}", imageModel.ImageFile.FileName, imageModel.ExtensionTo);
        ImageModel result = await Task.Run(() => _imageConverter.ConvertImage(imageModel));
        if (Request.HttpContext.Items["UserId"] is int userId)
        {
            _dBContext.AddImageToUserById(userId, result);
        }
        return File(result.ConvertedImageBytes, result.ContentType, result.ConvertedImageName);
    }
}
