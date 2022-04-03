namespace Conversion.Data
{
    internal record SIPrefix
    {
        internal string Name { get; set; }
        internal double ConvertRatio { get; set; }

        internal SIPrefix(string name, double convertRatio)
        {
            this.Name = name;
            this.ConvertRatio = convertRatio;
        }
    }
}