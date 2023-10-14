using System.Text.RegularExpressions;

namespace Chapter_14._5
{
    public class KebabCaseParameterTransformer
        : IOutboundParameterTransformer
    {
        public string? TransformOutbound(object? value)
        {

            if (value is null) return null;
            return Regex.Replace(value.ToString(),
                "([a-z]) ([A-Z])", "$1-$2").ToLower();
        }
    }
}
