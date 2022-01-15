namespace ImageConverterWebApi.Models;

public record class InputImageModel
{
    public IFormFile ImageFile { get; set; }
    public string ExtensionTo { get; set; }
}
