using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Conversion.Test
{
    [TestClass]
    public class ConversionStringTest
    {
        private Conversion convertor;

        public ConversionStringTest()
        {
            this.convertor = new Conversion();
        }

        [DataTestMethod]
        [DataRow("1 meter", "decimeter", "10 decimeter")]
        [DataRow("24 bit", "bite", "3 bite")]
        [DataRow("-10 celsius", "fahrenheit", "14 fahrenheit")]
        [TestMethod]
        public void SimpleTest(string input, string export, string expected)
        {
            Assert.AreEqual(expected, this.convertor.Convert(input, export));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input unit and export unit is different type.")]
        public void DifferentUnitException()
        {
            this.convertor.Convert("7 bite", "decimeter");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Input unit and export unit is different type.")]
        public void LowerMeasureValueException()
        {
            this.convertor.Convert("-7 meter", "decimeter");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Temperature is lower than absolute zero.")]
        public void LowerCelsiusValueException()
        {
            this.convertor.Convert("-700 celsius", "fahrenheit");
        }
    }
}