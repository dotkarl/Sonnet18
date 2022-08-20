using Sonnet18.Enums;
using Sonnet18.Helpers.Extensions;
using Sonnet18.Helpers.Strings;
using Sonnet18.Interfaces;

namespace Sonnet18.Model;

internal class Winds : IShaker
{
    private readonly Roughness _rough;

    public Winds(Roughness rough)
    {
        _rough = rough;
    }

    public string DoShake(IShakeable objectToShake)
    {
        var roughNess = EnumTranslator.DetermineRoughness(_rough);
        return $"{roughNess} {this.GetTypeName()} do shake the {objectToShake},";
    }
}