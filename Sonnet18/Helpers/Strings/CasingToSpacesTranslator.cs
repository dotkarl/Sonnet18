using System.Text.RegularExpressions;

namespace Sonnet18.Helpers.Strings;
public static class CasingToSpacesTranslator
{
    public static string ToSpaces(this string s)
    {
        return Regex
            .Replace(s, "(\\B[A-Z])", " $1")
            .ToLower();
    }
}
