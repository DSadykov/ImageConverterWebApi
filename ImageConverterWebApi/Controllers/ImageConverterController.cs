using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ImageConverterWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageConverterController : ControllerBase
{

    private readonly ILogger<ImageConverterController> _logger;
    private readonly ImageConverterService _imageConverter;
    private InputImageModel _imageModel;
    public ImageConverterController(ILogger<ImageConverterController> logger, ImageConverterService imageConverter)
    {
        _logger = logger;
        _imageConverter = imageConverter;
    }

    [HttpPost(Name = "PostImage")]
    public async Task<OutputImageModel> Post([FromBody] InputImageModel imageModel)
    {
        _imageModel = imageModel;
        return await _imageConverter.ConvertImage(_imageModel);
    }
}
