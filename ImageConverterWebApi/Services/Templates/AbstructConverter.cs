using System.Drawing;
using System.Drawing.Imaging;

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
    public IFormFile Convert(IFormFile imageFile)
    {
        ImageFormat outputFormat = SetOutputFormat();
        using Stream? inStream = imageFile.OpenReadStream();
        var outStream = new MemoryStream();
        var imageStream = Image.FromStream(inStream);
        imageStream.Save(outStream, outputFormat);
        var outputFormatString = outputFormat.ToString().ToLower();
        var result = new FormFile(outStream, 0, outStream.Length, imageFile.Name, Path.ChangeExtension(imageFile.FileName, outputFormatString))
        {
            Headers = new HeaderDictionary(),
            ContentType = $"image/{outputFormatString}",
        };
        return result;
    }
    protected abstract ImageFormat SetOutputFormat();
}
