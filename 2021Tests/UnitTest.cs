using aoc2021;
using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace aoc2021Tests
{
    [TestFixture]
    public class TestDay1
    {
        private readonly int day = 1;
        private List<int> input = null!;
        private List<int> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day, "input.txt").Select(int.Parse).ToList();
            exampleInput = ReadInputFile.GetInput(day, "exampleInput.txt").Select(int.Parse).ToList();
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day1.Part1(exampleInput.ToArray());
            Assert.AreEqual(7, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day1.Part1(input.ToArray());
            Assert.AreEqual(1559, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day1.Part2(input.ToArray());
            Assert.AreEqual(1600, answer);
        }
    }

    [TestFixture]
    public class TestDay2
    {
        private readonly int day = 2;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day, "input.txt");
            exampleInput = ReadInputFile.GetInput(day, "exampleInput.txt");
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day2.Part1(exampleInput);
            Assert.AreEqual(150, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day2.Part1(input);
            Assert.AreEqual(1690020, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day2.Part2(input);
            Assert.AreEqual(1408487760, answer);
        }
    }

}