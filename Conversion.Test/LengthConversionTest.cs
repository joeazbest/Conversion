using Conversion.Compute;
using Conversion.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Conversion.Test
{
    [TestClass]
    public class LengthConversionTest
    {
        [TestMethod]
        public void TestMethodSimple()
        {
            var meter = new FullUnit(
               new SIPrefix(string.Empty, 1),
               new UnitTypeName(
                   UnitType.Measure,
                   "meter",
                   new ConvertRate(0, 1),
                   (x) =>
                   {
                       return;
                   })
            );

            var feet = new FullUnit(
               new SIPrefix(string.Empty, 1),
               new UnitTypeName(
                   UnitType.Measure,
                   "feet",
                   new ConvertRate(0, 1.0 / 0.3048),
                   (x) =>
                   {
                       return;
                   })

            );

            var inch = new FullUnit(
              new SIPrefix(string.Empty, 1),
              new UnitTypeName(
                  UnitType.Measure,
                  "inch",
                  new ConvertRate(0, 1.0 / 0.0254),
                  (x) =>
                  {
                      return;
                  })

           );

            var dataConversion = new DataConversion();

            // drobna pomoc s zaokrouhlenim
            Assert.AreEqual(3.28, Math.Round(dataConversion.Convert(new ConvertData(1, meter, feet)), 2));

            Assert.AreEqual(39.37, Math.Round(dataConversion.Convert(new ConvertData(1, meter, inch)), 2));

            Assert.AreEqual(12, Math.Round(dataConversion.Convert(new ConvertData(1, feet, inch)), 5));
        }

        [TestMethod]
        public void TestMethodSi()
        {
            var kiloMeterUnit = new FullUnit(
               new SIPrefix("kilo", Math.Pow(10, 3)),
               new UnitTypeName(
                   UnitType.Measure,
                   "meter",
                   new ConvertRate(0, 1),
                   (x) =>
                   {
                       return;
                   })
            );

            var decaMeterUnit = new FullUnit(
               new SIPrefix("deca", Math.Pow(10, 1)),
               new UnitTypeName(
                   UnitType.Measure,
                   "meter",
                   new ConvertRate(0, 1),
                    (x) =>
                    {
                        return;
                    })
        );

            var deciMeterUnit = new FullUnit(
               new SIPrefix("deci", Math.Pow(10, -1)),
               new UnitTypeName(
                   UnitType.Measure,
                   "meter",
                   new ConvertRate(0, 1),
                   (x) =>
                   {
                       return;
                   })
            );

            var milliMeterUnit = new FullUnit(
               new SIPrefix("milli", Math.Pow(10, -3)),
               new UnitTypeName(
                   UnitType.Measure,
                   "meter",
                   new ConvertRate(0, 1),
                   (x) =>
                   {
                       return;
                   })
            );

            var dataConversion = new DataConversion();

            Assert.AreEqual(10000, dataConversion.Convert(new ConvertData(1, kiloMeterUnit, deciMeterUnit)));
        }
    }
}