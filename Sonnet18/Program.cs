using Sonnet18.Enums;
using Sonnet18.Helpers.Extensions;
using Sonnet18.Model;
using System.Drawing;
using I = Sonnet18.Helpers.Expressions;

var poet = new Poet("William Shakespeare");
poet.WritePoem("Sonnet 18",
    I.Ponder((i, thee, summersDay) =>
        i.Compare(thee, summersDay)),
    I.Assert((thee, summersDay) =>
        thee.Loveliness > summersDay.Loveliness &&
        thee.Temperateness > summersDay.Temperateness),
    I.Assert((roughWinds, darlingBudsOfMay) =>
        roughWinds.DoShake(darlingBudsOfMay)),
    I.Add((summersLease, date) =>
        summersLease.Hath(date, Length.AllTooShort)),

    I.Assert((sun) =>
        sun.Shine(options =>
        {
            options.AlternativeDescription = "eye of heaven";
            options.Times = Times.Some;
            options.Hotness = Hotness.Too;
        })),
    I.Add((his) =>
        his.Complexions.OfColor(Color.Gold).IsDimmed(Times.Often)),
    I.Add((fairs) =>
        fairs.Every(fair => fair.DeclinesAt == Times.Some)),
    I.Elaborate((by) =>
        by is Chance ||
        by is Course<Nature> c && c.IsChanging && !c.IsTrimmed),

    I.Contrast((thy) =>
        thy.Summers.OfType(Times.Eternal).ShallFade = false),
    I.Conjoin((thy) =>
        thy.Summers.LosePosession(thy.Fairness.That("thou ow'st"))),
    I.Conjoin((death, thou) =>
        death.ShallBrag(thou => thou.WanderingIn(death.Shade))),
    I.SpecifyWhen((lines, thou) =>
        thou.Grow(lines.Where(l =>
            l.Times == Times.Eternal && l.To == "time"))),

    I.SpecifyTime((men, eyes) =>
        men.Any(m => m.CanBreathe) || eyes.Any(e => e.CanSee)),
    I.SpecifyTime((@this, thee) =>
        @this.Lives().And(@this.GivesLife(thee)))
);
poet.Sign();

Console.Write(poet.ReadPoem());
Console.ReadLine();
