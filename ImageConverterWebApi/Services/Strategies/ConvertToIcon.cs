using System.Drawing;
using System.Drawing.Imaging;

namespace ImageConverterWebApi.Services.Strategies
{
    public class ConvertToIcon : AbstructConverter
    {
        protected override ImageFormat SetOutputFormat()
        {
            return ImageFormat.Icon;
        }
    }
}
