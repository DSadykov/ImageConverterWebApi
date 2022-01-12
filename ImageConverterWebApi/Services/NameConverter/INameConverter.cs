namespace ImageConverterWebApi.Services.NameConverter;

public interface INameConverter
{
    string ChangeExtension(string oldName, string toExtension);
}
