using Conversion.Compute.Interface;
using Conversion.Data;
using System.Collections.Generic;
using System.Linq;

namespace Conversion.Compute
{
    internal class SimpleParserInput : IParserInput
    {
        private Dictionary<string, FullUnit> fullUnits;

        public SimpleParserInput(Dictionary<string, FullUnit> fullUnits)
        {
            this.fullUnits = fullUnits;
        }

        public ConvertData Parse(string input, string expected)
        {
            input = input.Trim();

            var split = input.Split(" ");

            var value = double.Parse(split[0]);

            var inputUnit = ParseUnit(split[1]);
            var exportUnit = ParseUnit(expected.Trim());

            return new ConvertData(
                value,
                inputUnit,
                exportUnit
                );
        }

        private FullUnit ParseUnit(string unit)
        {
            unit = unit.ToLower();

            foreach (var fullUnit in this.fullUnits.OrderByDescending(t => t.Key.Length))
            {
                if (unit == fullUnit.Key || unit.Contains(fullUnit.Key))
                {
                    return fullUnit.Value;
                }
            }

            throw new System.ArgumentException(unit);
        }
    }
}