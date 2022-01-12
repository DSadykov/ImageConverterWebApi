﻿using System.Drawing;
using System.Drawing.Imaging;

namespace ImageConverterWebApi.Services.Strategies
{
    public class ConvertToBmp : AbstructConverter
    {
        protected override ImageFormat SetOutputFormat()
        {
            return ImageFormat.Bmp;
        }
    }
}
