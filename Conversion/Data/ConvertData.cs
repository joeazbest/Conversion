namespace Conversion.Data
{
    internal class ConvertData
    {
        internal double InputValue { get; set; }
        internal FullUnit InputUnit { get; set; }
        internal FullUnit ExportUnit { get; set; }

        internal ConvertData(double inportValue, FullUnit inputUnit, FullUnit exportUnit)
        {
            this.InputValue = inportValue;
            this.InputUnit = inputUnit;
            this.ExportUnit = exportUnit;
        }
    }
}