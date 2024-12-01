using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2024;

namespace aoc2024.Tests;

[TestFixture]
public class Day01Test
{
    private const int day = 01;
    private List<string> input = null!;
    private List<string> exampleInput = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        input = ReadInputFile.GetInputDayPadding(01, "input.txt");
        exampleInput = ReadInputFile.GetInputDayPadding(01, "exampleInput.txt");
    }

    [Test]
    public void ExamplePart1()
    {
        var answer = new Day01().Part1(exampleInput);
        Assert.That(answer, Is.EqualTo(11));
    }

    [Test]
    public void Part1()
    {
        var answer = new Day01().Part1(input);
        Assert.That(answer, Is.EqualTo(1579939));
    }

    [Test]
    public void ExamplePart2()
    {
        var answer = new Day01().Part2(exampleInput);
        Assert.That(answer, Is.EqualTo(31));
    }

    [Test]
    public void Part2()
    {
        var answer = new Day01().Part2(input);
        Assert.That(answer, Is.EqualTo(20351745));
    }

}
