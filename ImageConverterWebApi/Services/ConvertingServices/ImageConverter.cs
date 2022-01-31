using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services.Templates;

namespace ImageConverterWebApi.Services;

public class ImageConverter : IImageConverter
{
    private AbstructConverter _converter = new NullConvert();
    public byte[] ConvertImage(byte[] imageBytes)
    {
        return _converter.Convert(imageBytes);
    }

    public ImageModel ConvertImage(IFormFile imageFile)
    {
        return _converter.Convert(imageFile);
    }

    public Type GetConverterType()
    {
        return _converter.GetType();
    }

    public void SetConverter(AbstructConverter converter)
    {
        _converter = converter;
    }
}
