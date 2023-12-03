using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2023;

namespace aoc2023.Tests
{

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
        public void ExamplePart1()
        {
            var answer = new Day02().Part1(exampleInput);
            Assert.AreEqual(8, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = new Day02().Part1(input);
            Assert.AreEqual(2006, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = new Day02().Part2(exampleInput);
            Assert.AreEqual(2286, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = new Day02().Part2(input);
            Assert.AreEqual(84911, answer);
        }

    }
}
