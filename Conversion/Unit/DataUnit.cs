using Conversion.Data;
using Conversion.Unit.Interface;
using System.Collections.Generic;

namespace Conversion.Unit
{
    internal class DataUnit : IUnit
    {
        private List<SIPrefix> siPrefixis;
        private List<UnitTypeName> unitTypes;

        public DataUnit(List<SIPrefix> siPrefixis)
        {
            this.siPrefixis = siPrefixis;

            this.unitTypes = new List<UnitTypeName>()
            {
                new UnitTypeName(UnitType.Data, "bit", new ConvertRate(0, 1), (x) => {this.Validation(x); }),
                new UnitTypeName(UnitType.Data, "bite", new ConvertRate(0, 0.125), (x) => {this.Validation(x); })
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
                throw new System.ArgumentOutOfRangeException("Data is lower than zero");
            }
        }
    }
}