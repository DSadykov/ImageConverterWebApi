using ImageConverterWebApi.Attributes;
using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageConverterWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConvertedImagesController : ControllerBase
    {
        private readonly UsersDBContext _dBContext;

        public ConvertedImagesController(UsersDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        [HttpGet("GetImagesId")]
        [Authorize]
        public IEnumerable<ImageModelBase>? Get()
        {
            int? id = (int)Request.HttpContext.Items["UserId"];
            return _dBContext
                .ImageModels
                .Where(x => x.UserId == id)
                .Cast<ImageModelBase>();
        }
        [HttpGet("GetImageById")]
        [Authorize]
        public ActionResult Get(int imageId)
        {
            var userId = (int)Request.HttpContext.Items["UserId"];
            ImageModel? result = _dBContext.ImageModels.FirstOrDefault(x => x.Id == imageId);
            return result is null ? NotFound() :
                result.UserId != userId ? BadRequest("Image doesn't belong to authorized user") :
                File(result.ConvertedImageBytes, result.ContentType, result.ConvertedImageName);
        }
    }
}
