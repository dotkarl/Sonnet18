using Sonnet18.Interfaces;
using System.Text;

namespace Sonnet18.Model;

internal class Poet : IWritePoetry, IComparer
{
    private readonly StringBuilder _poemBuilder = new();

    public string FormOfAddress { get; }

    public Poet(string formOfAddress)
    {
        FormOfAddress = formOfAddress;
    }

    public string Compare(IObjectOfComparison subject, IObjectOfComparison @object)
    {
        return $"{FormOfAddress} compare {subject} to a {@object}";
    }

    public void WritePoem(string title, params string[] lines)
    {
        _poemBuilder.AppendLine(title);
        _poemBuilder.AppendLine();
        foreach (var line in lines)
        {
            WriteLine(line);
        }
    }

    public void WriteLine(string line)
    {
        if (string.IsNullOrEmpty(line))
        {
            _poemBuilder.AppendLine();
        }
        else
        {
            _poemBuilder.AppendLine(char.ToUpper(line[0]) + line.Substring(1));
        }
    }

    public string ReadPoem()
    {
        return _poemBuilder.ToString().Trim();
    }

    public void Sign()
    {
        _poemBuilder.AppendLine();
        _poemBuilder.AppendLine();
        _poemBuilder.AppendLine($"- {FormOfAddress}");
        _poemBuilder.AppendLine($"(generated on {DateTime.Now})");
    }
}