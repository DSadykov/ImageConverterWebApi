using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services.Templates;

namespace ImageConverterWebApi.Services;

public class ImageConverterService
{
    private readonly IImageConverter _imageConverter;
    private readonly ILogger<ImageConverterService> _logger;

    public ImageConverterService(IImageConverter imageConverter, ILogger<ImageConverterService> logger)
    {
        _imageConverter = imageConverter;
        _logger = logger;
    }

    public IFormFile ConvertImage(InputImageModel imageModel)
    {
        SetConverter(imageModel.ExtensionTo);
        _logger.LogInformation("Successfuly set converter to {imageConverterType}", _imageConverter.GetConverterType().Name);
        IFormFile? convertedImage = _imageConverter.ConvertImage(imageModel.ImageFile);
        _logger.LogInformation("Successfuly converted image to {toExtension}", Path.GetExtension(convertedImage.FileName));
        return convertedImage;
    }

    private void SetConverter(string extensionTo)
    {
        switch (extensionTo)
        {
            case "jpg":
            case "jpeg":
                _imageConverter.SetConverter(new ConvertToJpeg());
                break;
            case "png":
                _imageConverter.SetConverter(new ConvertToPng());
                break;
            case "bmp":
                _imageConverter.SetConverter(new ConvertToBmp());
                break;
            //case "ico":
            //case "icon":
            //    _imageConverter.SetConverter(new ConvertToIcon());
            //    break;
            default:
                _logger.LogWarning("Unsupported extension {extensionTo}", extensionTo);
                _imageConverter.SetConverter(new NullConvert());
                break;
        }
    }
}
