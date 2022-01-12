using System.Drawing;
using System.Drawing.Imaging;

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
    protected abstract ImageFormat SetOutputFormat();
}

