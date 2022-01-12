using ImageConverterWebApi.Services.Templates;

namespace ImageConverterWebApi.Services
{
    public interface IImageConverter
    {
        byte[] ConvertImage(byte[] imageBytes);
        IFormFile ConvertImage(IFormFile imageFile);
        void SetConverter(AbstructConverter converter);
    }
}