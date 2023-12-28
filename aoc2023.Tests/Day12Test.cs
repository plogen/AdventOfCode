using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2023;

namespace aoc2023.Tests
{

    [TestFixture]
    public class Day12Test
    {
        private const int day = 12;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(12, "input.txt");
            exampleInput = ReadInputFile.GetInputDayPadding(12, "exampleInput.txt");
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = new Day12().Part1(exampleInput);
            Assert.AreEqual(21, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = new Day12().Part1(input);
            Assert.AreEqual(-1, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = new Day12().Part2(exampleInput);
            Assert.AreEqual(-1, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = new Day12().Part2(input);
            Assert.AreEqual(-1, answer);
        }

    }
}
