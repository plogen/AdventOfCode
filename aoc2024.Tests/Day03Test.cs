using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2024;

namespace aoc2024.Tests;

[TestFixture]
public class Day03Test
{
    private const int day = 03;
    private List<string> input = null!;
    private List<string> exampleInput = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        input = ReadInputFile.GetInputDayPadding(03, "input.txt");
        exampleInput = ReadInputFile.GetInputDayPadding(03, "exampleInput.txt");
    }

    [Test]
    public void ExamplePart1()
    {
        var answer = new Day03().Part1(exampleInput);
        Assert.That(answer, Is.EqualTo(161));
    }

    [Test]
    public void Part1()
    {
        var answer = new Day03().Part1(input);
        Assert.That(answer, Is.EqualTo(173529487));
    }

    [Test]
    public void ExamplePart2()
    {
        var answer = new Day03().Part2(exampleInput);
        Assert.That(answer, Is.EqualTo(-1));
    }

    [Test]
    public void Part2()
    {
        var answer = new Day03().Part2(input);
        Assert.That(answer, Is.EqualTo(-1));
    }

}
