﻿using System.Drawing;
using System.Drawing.Imaging;

namespace ImageConverterWebApi.Services.Strategies
{
    public class NullConvert : AbstructConverter
    {
        protected override ImageFormat SetOutputFormat()
        {
            return ImageFormat.Bmp;
        }
    }
}
