using aoc2021;
using NUnit.Framework;

namespace Common.Tests
{
    
    [TestFixture]
    public class TestDay1
    {
        private readonly int day = 1;
        private int[] input;

        [SetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day).ToArray();
        }

        [Test]
        public void Part1()
        {
            var answer = Day1.Part1(input);
            Assert.AreEqual(1559, answer);
        }
    }
}