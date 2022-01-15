using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageConverterWebApi.Services.Templates.Tests
{
    [TestClass()]
    public class AbstructConverterTests
    {
        [TestMethod()]
        public void ConvertToBmpTest()
        {
            AbstructConverter converter = new ConvertToBmp();
        }
        [TestMethod()]
        public void ConvertToJpgTest()
        {
            AbstructConverter converter = new ConvertToJpeg();
        }
        [TestMethod()]
        public void ConvertToPngTest()
        {
            AbstructConverter converter = new ConvertToPng();
        }
    }
}