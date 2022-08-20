namespace Sonnet18.Helpers.Attributes;
internal class DisplayNameAttribute : Attribute
{
    public string DisplayName { get; }
    public DisplayNameAttribute(string data) { DisplayName = data; }
}
