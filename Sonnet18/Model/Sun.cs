using Sonnet18.Enums;
using Sonnet18.Helpers.Extensions;
using Sonnet18.Helpers.Strings;
using System.Drawing;

namespace Sonnet18.Model;
internal class Sun
{
    public Sun()
    {
        Complexions = new[]
        {
            new Complexion(Color.Gold),
            new Complexion(Color.Goldenrod),
            new Complexion(Color.DarkGoldenrod),
            new Complexion(Color.LightGoldenrodYellow),
            new Complexion(Color.PaleGoldenrod)
        };
    }

    public IEnumerable<Complexion> Complexions { get; set; }

    internal string Shine(Action<ShineOptions> options)
    {
        var o = new ShineOptions();
        options.Invoke(o);

        var times = EnumTranslator.DetermineTimes(o.Times);
        var hotness = EnumTranslator.DetermineHotness(o.Hotness);
        var name = o.AlternativeDescription ?? this.GetTypeName();
        return $"{times} {hotness} the {name} shines";
    }
}

internal class ShineOptions
{
    public string? AlternativeDescription { get; set; }
    public Times Times { get; set; }
    public Hotness Hotness { get; set; }
}
