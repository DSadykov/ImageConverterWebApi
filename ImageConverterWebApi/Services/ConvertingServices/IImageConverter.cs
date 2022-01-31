using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services.Templates;

namespace ImageConverterWebApi.Services;

public interface IImageConverter
{
    byte[] ConvertImage(byte[] imageBytes);
    ImageModel ConvertImage(IFormFile imageFile);
    void SetConverter(AbstructConverter converter);
    Type GetConverterType();
}
