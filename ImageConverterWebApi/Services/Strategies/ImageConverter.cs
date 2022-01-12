﻿using ImageConverterWebApi.Services.Strategies;
using System.Drawing;

namespace ImageConverterWebApi.Services
{
    public class ImageConverter : IImageConverter
    {
        private AbstructConverter _converter = new NullConvert();
        public byte[] ConvertImage(byte[] imageBytes)
        {
            return _converter.Convert(imageBytes);
        }

        public IFormFile ConvertImage(IFormFile imageFile)
        {
            return _converter.Convert(imageFile);
        }

        public void SetConverter(AbstructConverter converter)
        {
            _converter = converter;
        }
    }
}
