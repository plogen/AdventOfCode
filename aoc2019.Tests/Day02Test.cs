using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2019;

namespace aoc2019.Tests;

[TestFixture]
public class Day02Test
{
    private const int day = 02;
    private List<string> input = null!;
    private List<string> exampleInput = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        input = ReadInputFile.GetInputDayPadding(02, "input.txt");
        exampleInput = ReadInputFile.GetInputDayPadding(02, "exampleInput.txt");
    }

    [Test]
    public void Part1()
    {
        var answer = new Day02().Part1(input);
        Assert.That(answer, Is.EqualTo(4090689));
    }

    [Test]
    public void Part2()
    {
        var answer = new Day02().Part2(input);
        Assert.That(answer, Is.EqualTo(7733));
    }

}
