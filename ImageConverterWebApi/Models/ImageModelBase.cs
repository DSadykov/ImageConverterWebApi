using System.ComponentModel.DataAnnotations;

namespace ImageConverterWebApi.Models;

public class ImageModelBase
{
    [Key]
    public int Id { get; set; }
    public string FromImageName { get; set; }
    public string ConvertedImageName { get; set; }
}
