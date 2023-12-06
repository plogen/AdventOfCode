using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2023;

namespace aoc2023.Tests
{

    [TestFixture]
    public class Day06Test
    {
        private const int day = 06;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(06, "input.txt");
            exampleInput = ReadInputFile.GetInputDayPadding(06, "exampleInput.txt");
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = new Day06().Part1(exampleInput);
            Assert.AreEqual(288, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = new Day06().Part1(input);
            Assert.AreEqual(114400, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = new Day06().Part2(exampleInput);
            Assert.AreEqual(71503, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = new Day06().Part2(input);
            Assert.AreEqual(21039729, answer);
        }

    }
}
