using Common;
using static aoc2015.Day02;

namespace aoc2015.Tests
{

    [TestFixture]
    public class TestDay04
    {
        private readonly int day = 4;
        private string input = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputAsStringDayPadding(day, "input.txt");
        }

        [Test]
        [TestCase("abcdef", 609043)]
        [TestCase("pqrstuv", 1048970)]
        public void ExamplePart1(string input, int expected)
        {
            var answer = Day04.Part1(input);
            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day04.Part1(input);
            Assert.AreEqual(282749, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day04.Part2(input);
            Assert.AreEqual(9962624, answer);
        }
    }


}