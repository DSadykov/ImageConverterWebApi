using ImageConverterWebApi.Services.Strategies;

namespace ImageConverterWebApi.Services
{
    public interface IImageConverter
    {
        byte[] ConvertImage(byte[] imageBytes);
        void SetConverter(AbstructConverter converter);
    }
}