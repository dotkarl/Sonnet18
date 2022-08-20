namespace Sonnet18.Model;
internal class Poem
{
    public string FormOfAddress { get; }
    public bool IsAlive { get; set; }

    public Poem(string formOfAddress, bool lives)
    {
        FormOfAddress = formOfAddress;
        IsAlive = lives;
    }

    public string Lives()
    {
        return $"lives{(IsAlive ? "" : " not")} {FormOfAddress},";
    }

    public string GivesLife(Subject subject)
    {
        return $"{FormOfAddress} gives life to {subject}";
    }
}
