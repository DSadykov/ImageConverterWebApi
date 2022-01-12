using System.Drawing.Imaging;

namespace ImageConverterWebApi.Services.Templates;

public class NullConvert : AbstructConverter
{
    protected override ImageFormat SetOutputFormat()
    {
        return ImageFormat.Bmp;
    }
}
