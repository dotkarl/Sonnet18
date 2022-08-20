using Sonnet18.Enums;
using Sonnet18.Helpers.Extensions;
using Sonnet18.Helpers.Strings;

namespace Sonnet18.Model;

internal class Lease
{
    private Type _type;

    public Lease(Type type)
    {
        _type = type;
    }

    internal string Hath(Date date, Length length)
    {
        var l = EnumTranslator.DetermineLength(length);
        return $"{_type.GetTypeName()}'s {this.GetTypeName()} hath {l} a {date.GetTypeName()}";
    }
}