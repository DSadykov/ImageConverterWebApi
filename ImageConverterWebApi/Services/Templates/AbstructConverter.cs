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
        using var inStream = new MemoryStream();
        using var outStream = new MemoryStream();
        var imageStream = Image.FromStream(imageFile.OpenReadStream());
        imageStream.Save(outStream, outputFormat);
        var result = new FormFile(outStream, 0, outStream.Length, imageFile.Name, Path.ChangeExtension(imageFile.FileName, outputFormat.ToString()))
        {
            Headers = new HeaderDictionary(),
            ContentType = imageFile.ContentType,
        };
        return result;
    }
    protected abstract ImageFormat SetOutputFormat();
}
