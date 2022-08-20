using Sonnet18.Enums;
using Sonnet18.Model;
using System.Drawing;

namespace Sonnet18.Helpers.Extensions;
internal static class LinqExtensions
{
    public static bool Every<T>(this IEnumerable<T> t, Func<T, bool> predicate)
    {
        return t.All(predicate);
    }

    public static Complexion OfColor(this IEnumerable<Complexion> complexions, Color color)
    {
        return complexions.First(c => c.Color == color);
    }

    public static Summer OfType(this IEnumerable<Summer> summers, Times time)
    {
        return summers.First(s => s.Times == time);
    }

    public static string LosePosession<T>(this IEnumerable<T> posessor, Fair fairness)
    {
        return $"lose possession of that {fairness.GetTypeName()} {fairness.What}";
    }
}
