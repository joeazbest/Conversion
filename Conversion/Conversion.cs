using Conversion.Compute;
using Conversion.Compute.Interface;
using Conversion.Data;
using Conversion.Unit;
using Conversion.Unit.Interface;
using System;
using System.Collections.Generic;

namespace Conversion
{
    public class Conversion : IConversion
    {
        private List<IUnit> units;
        private SIPrefix emptySiPrefix;
        private List<SIPrefix> siPrefixis;
        private Dictionary<string, FullUnit> fullUnits;
        private IParserInput parser;
        private IInputValidator validator;
        private IDataConversion convertor;

        public Conversion()
        {
            this.emptySiPrefix = new SIPrefix(string.Empty, 1);

            this.siPrefixis = new List<SIPrefix>() {
                new SIPrefix("yotta", Math.Pow(10, 24)),
                new SIPrefix("zetta", Math.Pow(10, 21)),
                new SIPrefix("exa", Math.Pow(10, 18)),
                new SIPrefix("peta", Math.Pow(10, 15)),
                new SIPrefix("tera", Math.Pow(10, 12)),
                new SIPrefix("giga", Math.Pow(10, 9)),
                new SIPrefix("mega", Math.Pow(10, 6)),
                new SIPrefix("kilo", Math.Pow(10, 3)),
                new SIPrefix("hecto", Math.Pow(10, 2)),
                new SIPrefix("deca", Math.Pow(10, 1)),
                this.emptySiPrefix,
                new SIPrefix("deci", Math.Pow(10, -1)),
                new SIPrefix("centi", Math.Pow(10, -2)),
                new SIPrefix("milli", Math.Pow(10, -3)),
                new SIPrefix("micro", Math.Pow(10, -6)),
                new SIPrefix("nano", Math.Pow(10, -9)),
                new SIPrefix("pico", Math.Pow(10, -12)),
                new SIPrefix("femto", Math.Pow(10, -15)),
                new SIPrefix("atto", Math.Pow(10, -18)),
                new SIPrefix("zepto", Math.Pow(10, -21)),
                new SIPrefix("yocto", Math.Pow(10, -24)),
            };

            this.units = new List<IUnit>()
            {
                new DataUnit(this.siPrefixis),
                new TemperatureUnit(this.emptySiPrefix),
                new MeasureUnit(this.siPrefixis)
            };

            this.fullUnits = new Dictionary<string, FullUnit>();
            foreach (var unit in this.units)
            {
                var listPossibilities = unit.GetFullUnits();
                foreach (var possibility in listPossibilities)
                {
                    this.fullUnits.Add(possibility.ToString(), possibility);
                }
            }

            this.parser = new SimpleParserInput(this.fullUnits);
            this.validator = new InputValidator();
            this.convertor = new DataConversion();
        }

        public string Convert(string input, string expected)
        {
            // parsing
            var data = parser.Parse(input, expected);

            // validation
            this.validator.Validate(data);

            // Convert
            var output = this.convertor.Convert(data);

            return string.Format("{0} {1}", output.ToString(), data.ExportUnit.ToString());
        }
    }
}