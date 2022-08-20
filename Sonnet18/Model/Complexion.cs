using Sonnet18.Enums;
using Sonnet18.Helpers.Extensions;
using Sonnet18.Helpers.Strings;
using System.Drawing;

namespace Sonnet18.Model;

public record Complexion(Color Color)
{
    internal string IsDimmed(Times times)
    {
        var t = EnumTranslator.DetermineTimes(times);
        return $"{t} is his {Color.Name.ToLower()} {this.GetTypeName()} dimmed";
    }
}