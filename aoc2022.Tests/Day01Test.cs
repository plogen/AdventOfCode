using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace aoc2022.Tests
{

    [TestFixture]
    public class TestDay01
    {
        private readonly int day = 1;
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
            var answer = Day01.Part1(exampleInput);
            Assert.AreEqual(24000, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day01.Part1(input);
            Assert.AreEqual(74394, answer);
        }


        [Test]
        public void Part2()
        {
            var answer = Day01.Part2(input);
            Assert.AreEqual(212836, answer);
        }
    }


}