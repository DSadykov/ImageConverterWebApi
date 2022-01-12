using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    public async Task<IFormFile> /*string*/ Post([FromForm] InputImageModel imageModel)
    {
        return await Task.Run(() => _imageConverter.ConvertImage(imageModel).ImageFile);
        //return "2";
    }
    //[HttpPost(Name = "tmp")]
    //public string Post([FromForm] string str)
    //{
    //    _logger.LogInformation("Post came");
    //    return str;
    //}
    [HttpGet(Name = "123")]
    public string Get()
    {
        return "123";
    }
}
