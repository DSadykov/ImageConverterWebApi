using System.Drawing.Imaging;

namespace ImageConverterWebApi.Services.Templates;

public class ConvertToPng : AbstructConverter
{
    protected override ImageFormat SetOutputFormat()
    {
        return ImageFormat.Png;
    }
}
