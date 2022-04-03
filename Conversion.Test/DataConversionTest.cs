using Conversion.Compute;
using Conversion.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Conversion.Test
{
    [TestClass]
    public class DataConversionTest
    {
        [TestMethod]
        public void TestMethodSimple()
        {
            var bitUnit = new FullUnit(
                new SIPrefix(string.Empty, 1),
                new UnitTypeName(UnitType.Data, "bit", new ConvertRate(0, 1), (x) => { return; })
            );

            var biteUnite = new FullUnit(
               new SIPrefix(string.Empty, 1),
               new UnitTypeName(UnitType.Data, "bite", new ConvertRate(0, 0.125), (x) => { return; })
            );

            var dataconversion = new DataConversion();

            Assert.AreEqual(1, dataconversion.Convert(new ConvertData(8, bitUnit, biteUnite)));
            Assert.AreEqual(2, dataconversion.Convert(new ConvertData(16, bitUnit, biteUnite)));
            Assert.AreEqual(24, dataconversion.Convert(new ConvertData(3, biteUnite, bitUnit)));
        }

        [TestMethod]
        public void TestMethodSI()
        {
            var kiloBitUnit = new FullUnit(
                new SIPrefix("kilo", Math.Pow(10, 3)),
                new UnitTypeName(UnitType.Data, "bit", new ConvertRate(0, 1),
                (x) =>
                {
                    return;
                })
            );

            var decaBiteUnit = new FullUnit(
                new SIPrefix("deca", Math.Pow(10, 1)),
                new UnitTypeName(UnitType.Data, "bite", new ConvertRate(0, 0.125),
                (x) =>
                {
                    return;
                })
            );

            var dataconversion = new DataConversion();

            Assert.AreEqual(100, dataconversion.Convert(new ConvertData(8, kiloBitUnit, decaBiteUnit)));
            Assert.AreEqual(200, dataconversion.Convert(new ConvertData(16, kiloBitUnit, decaBiteUnit)));
        }
    }
}