using Conversion.Compute.Interface;
using Conversion.Data;

namespace Conversion.Compute
{
    internal class DataConversion : IDataConversion
    {
        public double Convert(ConvertData data)
        {
            return (data.InputValue + data.InputUnit.UnitType.ConvertRate.Shift) * data.ExportUnit.UnitType.ConvertRate.ConvertRatio * data.InputUnit.SiPrefix.ConvertRatio / data.InputUnit.UnitType.ConvertRate.ConvertRatio / data.ExportUnit.SiPrefix.ConvertRatio - data.ExportUnit.UnitType.ConvertRate.Shift;
        }
    }
}