using System.Drawing;
using System.Drawing.Imaging;
using ImageConverterWebApi.Models;

namespace ImageConverterWebApi.Services.Strategies;

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
        using (var inStream = new MemoryStream())
        using (var outStream = new MemoryStream())
        {
            imageFile.CopyTo(inStream);
            var imageStream = Image.FromStream(inStream);
            imageStream.Save(outStream, outputFormat);
            var tmp = outputFormat.ToString();
            return new FormFile(outStream, 0, outStream.Length, imageFile.Name, Path.ChangeExtension(imageFile.FileName, tmp));
        }
    }
    protected abstract ImageFormat SetOutputFormat();
}

