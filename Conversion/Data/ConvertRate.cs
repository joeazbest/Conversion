namespace Conversion.Data
{
    internal record ConvertRate
    {
        internal double Shift { get; set; }

        internal double ConvertRatio { get; set; }

        internal ConvertRate(double shift, double convertRatio)
        {
            this.Shift = shift;
            this.ConvertRatio = convertRatio;
        }
    }
}