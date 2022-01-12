namespace ImageConverterWebApi.Services.NameConverter;

public class NameConverter : INameConverter
{
    public string ChangeExtension(string oldName, string toExtension)
    {
        return Path.ChangeExtension(oldName, toExtension);
    }
}
