using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2023;

namespace aoc2023.Tests
{

    [TestFixture]
    public class Day08Test
    {
        private const int day = 08;
        private List<string> input = null!;
        private List<string> exampleInput = null!;
        private List<string> exampleInput2 = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(08, "input.txt");
            exampleInput = ReadInputFile.GetInputDayPadding(08, "exampleInput.txt");
            exampleInput2 = ReadInputFile.GetInputDayPadding(08, "exampleInput2.txt");
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = new Day08().Part1(exampleInput);
            Assert.AreEqual(6, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = new Day08().Part1(input);
            Assert.AreEqual(12599, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = new Day08().Part2(exampleInput2);
            Assert.AreEqual(6, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = new Day08().Part2(input);
            Assert.AreEqual(8245452805243, answer);
        }

    }
}
