using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2023;

namespace aoc2023.Tests
{

    [TestFixture]
    public class Day05Test
    {
        private const int day = 05;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(05, "input.txt");
            exampleInput = ReadInputFile.GetInputDayPadding(05, "exampleInput.txt");
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = new Day05().Part1(exampleInput);
            Assert.AreEqual(35, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = new Day05().Part1(input);
            Assert.AreEqual(278755257, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = new Day05().Part2(exampleInput);
            Assert.AreEqual(46, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = new Day05().Part2(input);
            Assert.AreEqual(26829166, answer); //326,6min, with same solution as part 1. Now in the morning I fugured that a reverse search from lowest destination to first seed hit would be faster. And remove the source destination strings with something like bytes.
        }

    }
}
