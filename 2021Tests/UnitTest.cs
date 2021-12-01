using aoc2021;
using Common;
using NUnit.Framework;

namespace _2021Tests
{
    [TestFixture]
    public class TestDay1
    {
        private readonly int day = 1;
        private int[] input;
        private int[] exampleInput;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day, "input.txt").ToArray();
            exampleInput = ReadInputFile.GetInput(day, "exampleInput.txt").ToArray();
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day1.Part1(exampleInput);
            Assert.AreEqual(7, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day1.Part1(input);
            Assert.AreEqual(1559, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day1.Part2(input);
            Assert.AreEqual(1600, answer);
        }
    }
}