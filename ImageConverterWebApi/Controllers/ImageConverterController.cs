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
    public IFormFile Post([FromForm] InputImageModel imageModel)
    {
        return _imageConverter.ConvertImage(imageModel);
    }
    //[HttpPost(Name = "PostImage")]
    //public async Task<OutputImageModel> Post(string imageModel)
    //{
    //    try
    //    {
    //        var tmp = Request.Form.Files;
    //        return new OutputImageModel() { ImageName = tmp.FirstOrDefault()?.FileName ?? "NULL CAME" };
    //    }
    //    catch (Exception)
    //    {
    //        return new OutputImageModel() { ImageName = "NULL FORM" };
    //    }
    //}
}
