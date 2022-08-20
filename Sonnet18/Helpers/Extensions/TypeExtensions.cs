namespace Sonnet18.Helpers.Extensions;
internal static class TypeExtensions
{
    public static string GetTypeName(this object o)
    {
        var type = o.GetType();
        var name = type.Name.ToLower();
        if (type.IsGenericType)
        {
            return name[..^2];
        }
        return name;
    }

    public static string GetTypeName(this Type t)
    {
        return t.Name.ToLower();
    }

    public static string GetTypeName<T>(this IEnumerable<T> ts)
    {
        var name = ts?.FirstOrDefault()?.GetTypeName();
        if (name is not null)
        {
            return name + "s";
        }
        return "";
    }
}
