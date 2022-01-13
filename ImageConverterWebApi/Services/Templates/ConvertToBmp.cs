using System.Drawing.Imaging;

namespace ImageConverterWebApi.Services.Templates;

public class ConvertToBmp : AbstructConverter
{
    protected override ImageFormat SetOutputFormat()
    {
        return ImageFormat.Bmp;
    }
}
