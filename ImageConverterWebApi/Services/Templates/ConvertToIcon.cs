using System.Drawing.Imaging;

namespace ImageConverterWebApi.Services.Templates;

public class ConvertToIcon : AbstructConverter
{
    protected override ImageFormat SetOutputFormat()
    {
        return ImageFormat.Icon;
    }
}
