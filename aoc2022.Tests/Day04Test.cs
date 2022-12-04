using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace aoc2022.Tests
{

    [TestFixture]
    public class TestDay04
    {
        private readonly int day = 4;
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
            var answer = Day04.Part1(exampleInput);
            Assert.AreEqual(2, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day04.Part1(input);
            Assert.AreEqual(567, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = Day04.Part2(exampleInput);
            Assert.AreEqual(4, answer);
        }


        [Test]
        public void Part2()
        {
            var answer = Day04.Part2(input);
            Assert.AreEqual(907, answer);
        }



    }


}