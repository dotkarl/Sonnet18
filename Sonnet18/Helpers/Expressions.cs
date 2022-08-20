using Sonnet18.Enums;
using Sonnet18.Helpers.Attributes;
using Sonnet18.Helpers.Extensions;
using Sonnet18.Helpers.Strings;
using Sonnet18.Interfaces;
using Sonnet18.Model;
using System.Globalization;
using System.Reflection;

namespace Sonnet18.Helpers;
internal static class Expressions
{
    internal static string Ponder(Func<IComparer, IObjectOfComparison, IObjectOfComparison, string> pondering)
    {
        return $"shall " + pondering.Invoke(
            new Poet("I"),
            new Subject("thee"),
            new Day(typeof(Summer))) + "?";
    }

    internal static string Assert(Func<IObjectOfComparison, IObjectOfComparison, bool> assertion)
    {
        var thou = new Subject("thou");
        var qualifier = assertion.Invoke(thou, new Day(typeof(Summer))) ? "more" : "less";
        var loveliness = thou.GetType()
            .GetInterface(nameof(IObjectOfComparison))
            .GetProperty(nameof(IObjectOfComparison.Loveliness))
            .GetCustomAttribute<DisplayNameAttribute>();
        var temperateness = thou.GetType()
            .GetInterface(nameof(IObjectOfComparison))
            .GetProperty(nameof(IObjectOfComparison.Temperateness))
            .GetCustomAttribute<DisplayNameAttribute>();
        return $"{thou.FormOfAddress} art {qualifier} {loveliness.DisplayName} and {qualifier} {temperateness.DisplayName}.";
    }

    internal static string Assert(Func<IShaker, IShakeable, string> assertion)
    {
        var winds = new Winds(Roughness.Standard);
        var buds = new Buds("darling", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat.GetMonthName(5));
        return assertion.Invoke(winds, buds);
    }

    internal static string Assert(Func<Sun, string> assertion)
    {
        var eyeOfHeaven = new Sun();
        return assertion.Invoke(eyeOfHeaven) + ",";
    }

    internal static string Add(Func<Lease, Date, string> addition)
    {
        var summersLease = new Lease(typeof(Summer));
        var date = new Date();
        return "and " + addition.Invoke(summersLease, date) + ".";
    }

    internal static string Add(Func<Sun, string> addition)
    {
        var eyeOfHeaven = new Sun();
        return "and " + addition.Invoke(eyeOfHeaven) + ",";
    }

    internal static string Add(Func<IEnumerable<Fair>, bool> addition)
    {
        var fair1 = new Fair(Times.Some);
        var fair2 = new Fair(Times.Some);
        var fair3 = new Fair(Times.Some);
        var fair = new[] { fair1, fair2, fair3 };

        var qualifier = addition.Invoke(fair) ? "every" : "some";
        var times = EnumTranslator.DetermineTimes(fair1.DeclinesAt);

        return $"and {qualifier} {fair1.GetTypeName()} from {nameof(fair)} {times} declines,";
    }

    internal static string Elaborate(Func<object, bool> elaboration)
    {
        var by1 = GetBy(elaboration, new Chance());
        var by2 = GetBy(elaboration, new Course<Nature> { IsChanging = true });
        return $"by {by1} or {by2};";
    }

    private static string GetBy(Func<object, bool> elaboration, Chance chance)
    {
        if (elaboration.Invoke(chance))
        {
            return chance.GetTypeName();
        }
        return string.Empty;
    }

    private static string GetBy<T>(Func<object, bool> elaboration, Course<T> course)
    {
        if (elaboration.Invoke(course))
        {
            var type = course.GetType().GetGenericArguments()[0].GetTypeName();
            var changing = course.IsChanging ? "changing" : "unchanging";
            var trimmed = course.IsTrimmed ? "trimmed" : "untrimmed";
            return $"{type}'s {changing} {course.GetTypeName()} {trimmed}";
        }
        return string.Empty;
    }

    internal static string Contrast(Action<Subject> contrast)
    {
        var subject = new Subject("thy");
        contrast.Invoke(subject);
        return $"but {subject} {Times.Eternal.ToString().ToLower()} {typeof(Summer).GetTypeName()} shall {(subject.Summers.OfType(Times.Eternal).ShallFade ? "" : "not ")}fade";
    }

    internal static string Conjoin(Func<Subject, string> addition)
    {
        var subject = new Subject("thy");
        var result = addition.Invoke(subject);
        return $"nor {result},";
    }

    internal static string Conjoin(Func<Death, Subject, string> addition)
    {
        var death = new Death();
        var subject = new Subject("thou");
        var result = addition.Invoke(death, subject);
        return $"nor {result}";
    }

    internal static string SpecifyWhen(Func<IEnumerable<Line>, Subject, string> when)
    {
        var lines = new Line[] { new Line(Times.Eternal, "time") };
        var subject = new Subject("thou");
        var result = when.Invoke(lines, subject);
        return $"when {result}.";
    }

    internal static string SpecifyTime(Func<IEnumerable<Man>, IEnumerable<Eye>, bool> soLong)
    {
        var men = new[] { new Man(), new Man(), new Man() };
        var eyes = new[] { new Eye(), new Eye(), new Eye() };
        var result = soLong.Invoke(men, eyes);
        return $"so long {(result ? $"as {nameof(men)} {nameof(Man.CanBreathe).ToSpaces()} or {nameof(eyes)} {nameof(Eye.CanSee).ToSpaces()}" : "")},";
    }

    internal static string SpecifyTime(Func<Poem, Subject, string> soLong)
    {
        var poem = new Poem("this", true);
        var subject = new Subject("thee");
        var result = soLong.Invoke(poem, subject);
        return $"so long {result}.";
    }
}
