using Conversion.Compute.Interface;
using Conversion.Data;
using System;

namespace Conversion
{
    internal class InputValidator : IInputValidator
    {
        public void Validate(ConvertData data)
        {
            if (data.InputUnit.UnitType.Type != data.ExportUnit.UnitType.Type)
            {
                throw new ArgumentException("Input unit and export unit is different type.");
            }

            data.InputUnit.UnitType.Validate(data.InputValue);
        }
    }
}