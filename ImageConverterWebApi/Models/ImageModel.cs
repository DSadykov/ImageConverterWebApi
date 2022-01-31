using System.ComponentModel.DataAnnotations.Schema;

namespace ImageConverterWebApi.Models
{
    [Table("ImageModels")]
    public class ImageModel : ImageModelBase
    {
        public byte[] ConvertedImageBytes { get; set; }
        public string ContentType { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}