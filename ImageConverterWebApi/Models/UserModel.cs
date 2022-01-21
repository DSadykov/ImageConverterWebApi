using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageConverterWebApi.Models
{
    [Table("Users")]
    public class UserModel
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        public List<ImageModel> ConvertedImages { get; set; }
    }
}
