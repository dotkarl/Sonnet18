using Sonnet18.Enums;
using Sonnet18.Helpers.Extensions;
using Sonnet18.Helpers.Strings;
using Sonnet18.Interfaces;

namespace Sonnet18.Model;

internal class Subject : IObjectOfComparison
{
    public string FormOfAddress { get; }
    public int Loveliness => int.MaxValue;
    public int Temperateness => int.MaxValue;
    public IEnumerable<Summer> Summers { get; set; }
    public Fair Fairness { get; set; }
    public bool LifeGiven { get; set; }

    public Subject(string formOfAddress)
    {
        FormOfAddress = formOfAddress;
        Summers = new[]
        {
            new Summer(Times.Never),
            new Summer(Times.Some),
            new Summer(Times.Often),
            new Summer(Times.Every),
            new Summer(Times.Eternal),
        };
        Fairness = new Fair(Times.Never);
    }

    public string WanderingIn(object someoneElsesPlace)
    {
        return $"{FormOfAddress} wander'st in his {someoneElsesPlace}";
    }

    public string Grow(IEnumerable<Line> where)
    {
        var l = where.First();
        return $"in {EnumTranslator.DetermineTimes(l.Times)} {where.GetTypeName()} to {l.To} {FormOfAddress} grow'st";
    }

    public override string ToString()
    {
        return FormOfAddress;
    }
}