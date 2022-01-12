using System.Drawing;
using System.Drawing.Imaging;

namespace ImageConverterWebApi.Services.Strategies
{
    public class ConvertToPng : AbstructConverter
    {
        protected override ImageFormat SetOutputFormat()
        {
            return ImageFormat.Png;
        }
    }
}
