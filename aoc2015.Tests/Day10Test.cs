using Common;
using static aoc2015.Day02;
using static aoc2015.Day07;

namespace aoc2015.Tests
{

    [TestFixture]
    public class TestDay10
    {

        [OneTimeSetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, 11)]
        [TestCase(11, 21)]
        [TestCase(21, 1211)]
        [TestCase(1211, 111221)]
        [TestCase(111221, 312211)]
        public void ExamplePart1(int input, int expected)
        {
            var answer = Day10.Part1(input);
            Assert.AreEqual(expected, answer);
        }

        [Test]
        [TestCase(1321131112, 0)]
        public void Part1(int input, int expected)
        {
            var answer = Day10.Part1(input);
            Assert.AreEqual(0, answer);
        }

        [Test]
        [TestCase(-1, 0)]
        public void Part2(int input, int expected)
        {
            var answer = Day10.Part2(input);
            Assert.AreEqual(0, answer);
        }
    }


}