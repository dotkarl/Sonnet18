using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sonnet18.Enums;
using Sonnet18.Helpers;
using Sonnet18.Helpers.Extensions;
using Sonnet18.Model;
using System.Drawing;

namespace Sonnet18.Tests;

[TestClass]
public class PoetryWritingTests
{
    private Poet _poet;

    [TestInitialize]
    public void Init()
    {
        _poet = new Poet("Test Poet");
    }

    [TestMethod]
    public void PoetCanWrite_ShallICompareTheeToASummersDay()
    {
        _poet.WriteLine(Expressions.Ponder((i, thee, summersDay) =>
            i.Compare(thee, summersDay)));
        _poet.ReadPoem().Should().Be("Shall I compare thee to a summer's day?");
    }

    [TestMethod]
    public void PoetCanWrite_ThouArtMoreLovelyAndMoreTemperate()
    {
        _poet.WriteLine(Expressions.Assert((thee, summersDay) =>
            thee.Loveliness > summersDay.Loveliness &&
            thee.Temperateness > summersDay.Temperateness));
        _poet.ReadPoem().Should().Be("Thou art more lovely and more temperate.");
    }

    [TestMethod]
    public void PoetCanWrite_RoughWindsDoShakeTheDarlingBudsOfMay()
    {
        _poet.WriteLine(Expressions.Assert((roughWinds, darlingBudsOfMay) =>
            roughWinds.DoShake(darlingBudsOfMay)));
        _poet.ReadPoem().Should().Be("Rough winds do shake the darling buds of May,");
    }

    [TestMethod]
    public void PoetCanWrite_AndSummersLeaseHathAllToShortADate()
    {
        _poet.WriteLine(Expressions.Add((summersLease, date) =>
            summersLease.Hath(date, Length.AllTooShort)));
        _poet.ReadPoem().Should().Be("And summer's lease hath all too short a date.");
    }

    [TestMethod]
    public void PoetCanWrite_SometimeTooHotTheEyeOfHeavenShines()
    {
        _poet.WriteLine(Expressions.Assert((sun) =>
            sun.Shine(options =>
            {
                options.AlternativeDescription = "eye of heaven";
                options.Times = Times.Some;
                options.Hotness = Hotness.Too;
            })));
        _poet.ReadPoem().Should().Be("Sometime too hot the eye of heaven shines,");
    }

    [TestMethod]
    public void PoetCanWrite_AndOftenIsHisGoldComplexionDimmed()
    {
        _poet.WriteLine(Expressions.Add((sun) =>
            sun.Complexions.OfColor(Color.Gold).IsDimmed(Times.Often)));
        _poet.ReadPoem().Should().Be("And often is his gold complexion dimmed,");
    }

    [TestMethod]
    public void PoetCanWrite_AndEveryFairFromFairSometimeDecline()
    {
        _poet.WriteLine(Expressions.Add((fairs) =>
            fairs.Every(fair => fair.DeclinesAt == Times.Some)));
        _poet.ReadPoem().Should().Be("And every fair from fair sometime declines,");
    }

    [TestMethod]
    public void PoetCanWrite_ByChangeOrNaturesChangingCourseUntrimmed()
    {
        _poet.WriteLine(Expressions.Elaborate((by) => 
            by is Chance || by is Course<Nature> c && c.IsChanging && !c.IsTrimmed));
        _poet.ReadPoem().Should().Be("By chance or nature's changing course untrimmed;");
    }

    [TestMethod]
    public void PoetCanWrite_ButThyEternalSummerShallNotFade()
    {
        _poet.WriteLine(Expressions.Contrast((thy) =>
            thy.Summers.OfType(Times.Eternal).ShallFade = false));
        _poet.ReadPoem().Should().Be("But thy eternal summer shall not fade");
    }

    [TestMethod]
    public void PoetCanWrite_NorLosePosessionOfThatFairThouOwst()
    {
        _poet.WriteLine(Expressions.Conjoin((thy) =>
            thy.Summers.LosePosession(thy.Fairness.That("thou ow'st"))));
        _poet.ReadPoem().Should().Be("Nor lose possession of that fair thou ow'st,");
    }

    [TestMethod]
    public void PoetCanWrite_NorShallDeathBragThouWanderstInHisShade()
    {
        _poet.WriteLine(Expressions.Conjoin((death, thou) => 
            death.ShallBrag(thou => thou.WanderingIn(death.Shade))));
        _poet.ReadPoem().Should().Be("Nor shall death brag thou wander'st in his shade");
    }

    [TestMethod]
    public void PoetCanWrite_WhenInEternalLinesToTimeThouGrowst()
    {
        _poet.WriteLine(Expressions.SpecifyWhen((lines, thou) =>
            thou.Grow(lines.Where(l => 
                l.Times == Times.Eternal &&
                l.To == "time"))));
        _poet.ReadPoem().Should().Be("When in eternal lines to time thou grow'st.");
    }

    [TestMethod]
    public void PoetCanWrite_SoLongAsMenCanBreatheOrEyesCanSee()
    {
        _poet.WriteLine(Expressions.SpecifyTime((men, eyes) =>
            men.Any(m => m.CanBreathe) || eyes.Any(e => e.CanSee)));
        _poet.ReadPoem().Should().Be("So long as men can breathe or eyes can see,");
    }

    [TestMethod]
    public void PoetCanWrite_SoLangLivesThisAndGivesLifeToThee()
    {
        _poet.WriteLine(Expressions.SpecifyTime((@this, thee) => 
            @this.Lives().And(@this.GivesLife(thee))));
        _poet.ReadPoem().Should().Be("So long lives this, and this gives life to thee.");
    }
}