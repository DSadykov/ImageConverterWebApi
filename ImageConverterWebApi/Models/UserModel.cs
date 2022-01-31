using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ImageConverterWebApi.Models
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [PasswordPropertyText]
        [JsonIgnore]
        public string Password { get; set; }
        public List<ImageModel> ConvertedImages { get; set; } = new();
    }
}
