using Sonnet18.Helpers.Extensions;
using Sonnet18.Interfaces;

namespace Sonnet18.Model;

internal class Day : IObjectOfComparison
{
    private Type _typeOfDay;

    public int Loveliness => 16;
    public int Temperateness => 17;

    public Day(Type typeOfDay)
    {
        _typeOfDay = typeOfDay;
    }

    public override string ToString()
    {
        return $"{_typeOfDay.GetTypeName()}'s day";
    }
}