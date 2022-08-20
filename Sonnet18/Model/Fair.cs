using Sonnet18.Enums;

namespace Sonnet18.Model;

internal class Fair
{
    public string What { get; private set; }
    public Times DeclinesAt { get; }

    public Fair(Times DeclinesAt)
    {
        this.DeclinesAt = DeclinesAt;
    }

    public Fair That(string that)
    {
        What = that;
        return this;
    }
}
