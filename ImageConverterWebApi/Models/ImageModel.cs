namespace ImageConverterWebApi.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string FromImageName { get; set; }
        public string ConvertedImageName { get; set; }
        public byte[] ConvertedImage { get; set; }
        public UserModel User { get; set; }
    }
}