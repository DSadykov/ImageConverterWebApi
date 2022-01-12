using System.Drawing;
using Newtonsoft.Json;

namespace ImageConverterWebApi.Models
{
    public record class InputImageModel
    {
        public string ImageName { get; set; }
        public byte[] ImageBytes { get; set; }
        public string ExtensionTo { get; set; }

    }
}
