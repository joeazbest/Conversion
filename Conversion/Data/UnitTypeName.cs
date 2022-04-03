using System;

namespace Conversion.Data
{
    internal class UnitTypeName
    {
        internal UnitType Type { get; set; }
        internal string Name { get; set; }
        internal ConvertRate ConvertRate { get; set; }
        public Action<double> Validate { get; set; }

        internal UnitTypeName(UnitType type, string name, ConvertRate convertRate, Action<double> validate)
        {
            this.Type = type;
            this.Name = name;
            this.ConvertRate = convertRate;
            this.Validate = validate;
        }
    }
}