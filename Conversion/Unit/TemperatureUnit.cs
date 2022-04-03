using Conversion.Data;
using Conversion.Unit.Interface;
using System;
using System.Collections.Generic;

namespace Conversion.Unit
{
    internal class TemperatureUnit : IUnit
    {
        private SIPrefix emptyPrefix;
        private UnitTypeName celsius;
        private UnitTypeName fahrenheit;

        public TemperatureUnit(SIPrefix emptyPrefix)
        {
            this.emptyPrefix = emptyPrefix;

            this.celsius = new UnitTypeName(UnitType.Temperature, "celsius", new ConvertRate(40, 1.0), this.CelsiusValidation);
            this.fahrenheit = new UnitTypeName(UnitType.Temperature, "fahrenheit", new ConvertRate(40, 1.8), this.FahrnheitValidatio);
        }

        public List<FullUnit> GetFullUnits()
        {
            return new List<FullUnit>()
            {
                new FullUnit(emptyPrefix, this.celsius),
                new FullUnit(emptyPrefix, this.fahrenheit)
            };
        }

        public void CelsiusValidation(double value)
        {
            // lower then absolute zero
            if (value < -273.15)
            {
                throw new ArgumentOutOfRangeException("Temperature is lower than absolute zero.");
            }
        }

        private void FahrnheitValidatio(double value)
        {
            // lower then absolute zero
            if (value < -459.67)
            {
                throw new ArgumentOutOfRangeException("Temperature is lower than absolute zero.");
            }
        }
    }
}