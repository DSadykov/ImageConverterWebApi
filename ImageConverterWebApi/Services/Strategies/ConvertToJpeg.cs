using System.Drawing;
using System.Drawing.Imaging;

namespace ImageConverterWebApi.Services.Strategies
{
    public class ConvertToJpeg : AbstructConverter
    {
        protected override ImageFormat SetOutputFormat()
        {
            return ImageFormat.Jpeg;
        }
    }
}
