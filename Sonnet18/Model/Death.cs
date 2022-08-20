using Sonnet18.Helpers.Extensions;

namespace Sonnet18.Model;
internal class Death
{
    public string Shade => "shade";

    public string ShallBrag(Func<Subject, string> about)
    {
        var subject = new Subject("thou");
        var result = about.Invoke(subject);
        return $"shall {this.GetTypeName()} brag {result}";
    }
}
