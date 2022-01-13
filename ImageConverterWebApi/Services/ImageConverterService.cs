using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services.Templates;

namespace ImageConverterWebApi.Services;

public class ImageConverterService
{
    private readonly IImageConverter _imageConverter;

    public ImageConverterService(IImageConverter imageConverter)
    {
        _imageConverter = imageConverter;
    }

    public IFormFile ConvertImage(InputImageModel imageModel)
    {
        SetConverter(imageModel.ExtensionTo);
        IFormFile? convertedImage = _imageConverter.ConvertImage(imageModel.ImageFile);
        return convertedImage;
    }

    private void SetConverter(string extensionTo)
    {
        switch (extensionTo)
        {
            case "jpg":
                _imageConverter.SetConverter(new ConvertToJpeg());
                break;
            case "png":
                _imageConverter.SetConverter(new ConvertToPng());
                break;
            case "bmp":
                _imageConverter.SetConverter(new ConvertToBmp());
                break;
            case "ico":
                _imageConverter.SetConverter(new ConvertToIcon());
                break;
            default:
                _imageConverter.SetConverter(new NullConvert());
                break;
        }
    }
}
