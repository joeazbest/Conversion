using Conversion.Data;
using Conversion.Unit.Interface;
using System.Collections.Generic;

namespace Conversion.Unit
{
    internal class MeasureUnit : IUnit
    {
        private List<SIPrefix> siPrefixis;
        private List<UnitTypeName> unitTypes;

        public MeasureUnit(List<SIPrefix> siPrefixis)
        {
            this.siPrefixis = siPrefixis;
            this.unitTypes = new List<UnitTypeName>()
            {
                new UnitTypeName(UnitType.Measure, "meter", new ConvertRate(0, 1), (x) => { this.Validation(x); }),
                new UnitTypeName(UnitType.Measure, "feet", new ConvertRate(0, 1.0 / 0.3048), (x) => { this.Validation(x); }),
                new UnitTypeName(UnitType.Measure, "inch", new ConvertRate(0, 1.0 / 0.0254), (x) => { this.Validation(x); })
            };
        }

        public List<FullUnit> GetFullUnits()
        {
            var output = new List<FullUnit>();
            foreach (var siPrefix in this.siPrefixis)
            {
                foreach (var unitType in this.unitTypes)
                {
                    output.Add(new FullUnit(siPrefix, unitType));
                }
            }

            return output;
        }

        public void Validation(double value)
        {
            if (value < 0)
            {
                throw new System.ArgumentOutOfRangeException("Measure is lower than zero");
            }
        }
    }
}