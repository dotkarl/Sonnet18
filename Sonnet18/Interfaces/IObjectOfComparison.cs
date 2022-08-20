using Sonnet18.Helpers.Attributes;

namespace Sonnet18.Interfaces;

internal interface IObjectOfComparison
{
    [DisplayName("lovely")]
    public int Loveliness { get; }
    [DisplayName("temperate")]
    public int Temperateness { get; }
}