using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2023;
using System.Numerics;

namespace aoc2023.Tests
{

    [TestFixture]
    public class Day09Test
    {
        private const int day = 09;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(09, "input.txt");
            exampleInput = ReadInputFile.GetInputDayPadding(09, "exampleInput.txt");
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = new Day09().Part1(exampleInput);
            Assert.AreEqual(new BigInteger(114), answer);
        }

        [Test]
        public void Part1()
        {
            var answer = new Day09().Part1(input);
            Assert.AreEqual(new BigInteger(1939607039), answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = new Day09().Part2(exampleInput);
            Assert.AreEqual(-1, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = new Day09().Part2(input);
            Assert.AreEqual(-1, answer);
        }

    }
}
