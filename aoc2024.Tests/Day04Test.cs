using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2024;

namespace aoc2024.Tests;

[TestFixture]
public class Day04Test
{
    private const int day = 04;
    private List<string> input = null!;
    private List<string> exampleInput = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        input = ReadInputFile.GetInputDayPadding(04, "input.txt");
        exampleInput = ReadInputFile.GetInputDayPadding(04, "exampleInput.txt");
    }

    [Test]
    public void ExamplePart1()
    {
        var answer = new Day04().Part1(exampleInput);
        Assert.That(answer, Is.EqualTo(18));
    }

    [Test]
    public void Part1()
    {
        var answer = new Day04().Part1(input);
        Assert.That(answer, Is.EqualTo(2654));
    }

    [Test]
    public void ExamplePart2()
    {
        var answer = new Day04().Part2(exampleInput);
        Assert.That(answer, Is.EqualTo(-1));
    }

    [Test]
    public void Part2()
    {
        var answer = new Day04().Part2(input);
        Assert.That(answer, Is.EqualTo(-1));
    }

}
