using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2023;

namespace aoc2023.Tests
{

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
            Assert.AreEqual(4361, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = new Day03().Part1(input);
            Assert.AreEqual(544433, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = new Day03().Part2(exampleInput);
            Assert.AreEqual(467835, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = new Day03().Part2(input);
            Assert.AreEqual(76314915, answer);
        }

    }
}
