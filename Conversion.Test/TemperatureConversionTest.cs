using Conversion.Compute;
using Conversion.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conversion.Test
{
    [TestClass]
    public class TemperatureConversionTest
    {
        [TestMethod]
        public void ConversionTest()
        {
            var celsius = new FullUnit(
                new SIPrefix(string.Empty, 1),
                new UnitTypeName(
                    UnitType.Temperature,
                    "celsius",
                    new ConvertRate(40, 1.0),
                   (x) =>
                   {
                       return;
                   })
            );

            var fahrenheit = new FullUnit(
                new SIPrefix(string.Empty, 1),
                new UnitTypeName(
                    UnitType.Temperature,
                    "fahrenheit",
                    new ConvertRate(40, 1.8),
                    (x) =>
                    {
                        return;
                    })
            );

            var dataConversion = new DataConversion();

            // celsius -> fahrnhait
            Assert.AreEqual(-40, dataConversion.Convert(new ConvertData(-40, celsius, fahrenheit)));
            Assert.AreEqual(-22, dataConversion.Convert(new ConvertData(-30, celsius, fahrenheit)));
            Assert.AreEqual(14, dataConversion.Convert(new ConvertData(-10, celsius, fahrenheit)));
            Assert.AreEqual(32, dataConversion.Convert(new ConvertData(0, celsius, fahrenheit)));
            Assert.AreEqual(50, dataConversion.Convert(new ConvertData(10, celsius, fahrenheit)));
            Assert.AreEqual(104, dataConversion.Convert(new ConvertData(40, celsius, fahrenheit)));

            // fahrnhait -> celsius
            Assert.AreEqual(-40, dataConversion.Convert(new ConvertData(-40, fahrenheit, celsius)));
            Assert.AreEqual(-30, dataConversion.Convert(new ConvertData(-22, fahrenheit, celsius)));
            Assert.AreEqual(-10, dataConversion.Convert(new ConvertData(14, fahrenheit, celsius)));
            Assert.AreEqual(0, dataConversion.Convert(new ConvertData(32, fahrenheit, celsius)));
            Assert.AreEqual(10, dataConversion.Convert(new ConvertData(50, fahrenheit, celsius)));
            Assert.AreEqual(40, dataConversion.Convert(new ConvertData(104, fahrenheit, celsius)));
        }
    }
}