using Sonnet18.Enums;

namespace Sonnet18.Helpers.Strings;
internal static class EnumTranslator
{
    internal static string DetermineTimes(Times times)
    {
        return times switch
        {
            Times.Never => "never",
            Times.Some => "sometime",
            Times.Every => "everytime",
            Times.Often => "often",
            Times.Eternal => "eternal",
            Times.SoLong => "so long",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string DetermineHotness(Hotness hotness)
    {
        return hotness switch
        {
            Hotness.Not => "not hot",
            Hotness.AlmostEnough => "almost hot enough",
            Hotness.JustEnough => "just hot enough",
            Hotness.Too => "too hot",
            Hotness.Extreme => "extremely hot",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string DetermineLength(Length length)
    {
        return length switch
        {
            Length.AllTooShort => "all too short",
            Length.TooShort => "too short",
            Length.Short => "short",
            Length.Standard => "",
            Length.Long => "long",
            Length.TooLong => "too long",
            Length.AllTooLong => "all too long",
            _ => throw new NotImplementedException(),
        };
    }

    internal static string DetermineRoughness(Roughness roughness)
    {
        return roughness switch
        {
            Roughness.None => "",
            Roughness.Mild => "mildly rough",
            Roughness.Standard => "rough",
            Roughness.Very => "very rough",
            _ => throw new NotImplementedException(),
        };
    }
}
