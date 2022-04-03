namespace Conversion.Data
{
    internal class FullUnit
    {
        internal SIPrefix SiPrefix { get; set; }
        internal UnitTypeName UnitType { get; set; }

        internal FullUnit(SIPrefix sIPrefix, UnitTypeName unitType)
        {
            SiPrefix = sIPrefix;
            this.UnitType = unitType;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", SiPrefix.Name, UnitType.Name);
        }
    }
}