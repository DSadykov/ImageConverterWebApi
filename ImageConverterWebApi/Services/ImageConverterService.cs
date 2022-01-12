using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services.NameConverter;
using ImageConverterWebApi.Services.Strategies;

namespace ImageConverterWebApi.Services;

public class ImageConverterService
{
    private readonly IImageConverter _imageConverter;
    private readonly INameConverter _nameConverter;

    public ImageConverterService(IImageConverter imageConverter, INameConverter nameConverter)
    {
        _imageConverter = imageConverter;
        _nameConverter = nameConverter;
    }

    public async Task<OutputImageModel> ConvertImage(InputImageModel imageModel)
    {
        SetConverter(imageModel.ExtensionTo);
        var convertedBytes = _imageConverter.ConvertImage(imageModel.ImageBytes);
        OutputImageModel newImageModel = new()
        {
            ImageBytes = convertedBytes,
            ImageName = _nameConverter.ChangeExtension(imageModel.ImageName, imageModel.ExtensionTo)
        };
        return newImageModel;
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
