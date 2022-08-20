using Sonnet18.Enums;

namespace Sonnet18.Model;

internal class Summer
{
    public Times Times { get; set; }
    public bool ShallFade { get; set; }

    public Summer(Times times)
    {
        Times = times;
    }
}