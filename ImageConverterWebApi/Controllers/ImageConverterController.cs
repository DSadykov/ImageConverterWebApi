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
    public ImageConverterController(ILogger<ImageConverterController> logger, ImageConverterService imageConverter)
    {
        _logger = logger;
        _imageConverter = imageConverter;
    }

    [HttpPost(Name = "PostImage")]
    public async Task<OutputImageModel> Post([FromForm] InputImageModel imageModel)
    {
        return await _imageConverter.ConvertImage(imageModel);
    }
    //[HttpPost(Name = "PostImage")]
    //public async Task<OutputImageModel> Post([FromForm] byte[] imageModel)
    //{
    //    var tmp = imageModel;
    //    return new OutputImageModel() { ImageBytes = imageModel };
    //}
}
