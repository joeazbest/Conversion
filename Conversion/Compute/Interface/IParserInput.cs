using Conversion.Data;

namespace Conversion.Compute.Interface
{
    internal interface IParserInput
    {
        ConvertData Parse(string input, string expected);
    }
}