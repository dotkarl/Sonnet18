using Sonnet18.Helpers.Extensions;
using Sonnet18.Interfaces;

namespace Sonnet18.Model;

internal class Buds : IShakeable
{
    public string Qualifier { get; }
    public string MonthName { get; }

    public Buds(string qualifier, string monthName)
    {
        Qualifier = qualifier;
        MonthName = monthName;
    }

    public override string ToString()
    {
        return $"{Qualifier} {this.GetTypeName()} of {MonthName}";
    }
}