using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace aoc2022.Tests
{

    [TestFixture]
    public class TestDay07
    {
        private readonly int day = 7;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(day, "input.txt");
            exampleInput = ReadInputFile.GetInputDayPadding(day, "exampleInput.txt");
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day07.Part1(exampleInput);
            Assert.AreEqual(95437, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day07.Part1(input);
            Assert.AreEqual(1432936, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = Day07.Part2(exampleInput);
            Assert.AreEqual(24933642, answer);
        }


        [Test]
        public void Part2()
        {
            var answer = Day07.Part2(input);
            Assert.AreEqual(0, answer);
        }



    }


}