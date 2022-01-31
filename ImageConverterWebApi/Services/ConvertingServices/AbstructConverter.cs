using System.Drawing;
using System.Drawing.Imaging;
using ImageConverterWebApi.Models;

namespace ImageConverterWebApi.Services.Templates;

public abstract class AbstructConverter
{
    public byte[] Convert(byte[] imageBytes)
    {
        ImageFormat outputFormat = SetOutputFormat();
        using (var inStream = new MemoryStream(imageBytes))
        using (var outStream = new MemoryStream())
        {
            var imageStream = Image.FromStream(inStream);
            imageStream.Save(outStream, outputFormat);
            return outStream.ToArray();
        }
    }
    public ImageModel Convert(IFormFile imageFile)
    {
        ImageFormat outputFormat = SetOutputFormat();
        using Stream? inStream = imageFile.OpenReadStream();
        var outStream = new MemoryStream();
        var imageStream = Image.FromStream(inStream);
        imageStream.Save(outStream, outputFormat);
        var outputFormatString = outputFormat.ToString().ToLower();
        var result = new ImageModel()
        {
            ContentType = $"image/{outputFormatString}",
            ConvertedImageBytes = outStream.ToArray(),
            ConvertedImageName = Path.ChangeExtension(imageFile.FileName, outputFormatString),
            FromImageName = imageFile.FileName
        };
        return result;
    }
    protected abstract ImageFormat SetOutputFormat();
}
