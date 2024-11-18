using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2019;

namespace aoc2019.Tests;

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
    [TestCase(2, 12)]
    [TestCase(2, 14)]
    [TestCase(654, 1969)]
    [TestCase(33583, 100756)]
    public void ExamplePart1(int expected, int input)
    {
        var answer = new Day01().Part1(new List<string>{ input.ToString() });
        Assert.That(expected, Is.EqualTo(answer));
    }

    [Test]
    public void Part1()
    {
        var answer = new Day01().Part1(input);
        Assert.That(answer, Is.EqualTo(3372695));
    }

    [Test]
    [TestCase(2, 14)]
    [TestCase(966, 1969)]
    [TestCase(50346, 100756)]

    public void ExamplePart2(int expected, int input)
    {
        var answer = new Day01().Part2(new List<string> { input.ToString() });
        Assert.That(answer, Is.EqualTo(expected));
    }

    [Test]
    public void Part2()
    {
        var answer = new Day01().Part2(input);
        Assert.That(answer, Is.EqualTo(5056172));
    }

}
