using Common;
using static aoc2015.Day02;

namespace aoc2015.Tests
{

    [TestFixture]
    public class TestDay03
    {
        private readonly int day = 3;
        private string input = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputAsStringDayPadding(day, "input.txt");
        }

        [Test]
        [TestCase(">", 2)]
        [TestCase("^>v<", 4)]
        [TestCase("^v^v^v^v^v", 2)]
        public void ExamplePart1(string input, int expected)
        {
            var answer = Day03.Part1(input);
            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day03.Part1(input);
            Assert.AreEqual(2081, answer);
        }


        [Test]
        [TestCase("^v", 3)]
        [TestCase("^>v<", 3)]
        [TestCase("^v^v^v^v^v", 11)]
        public void ExamplePart2(string input, int expected)
        {
            var answer = Day03.Part2(input);
            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Part2()
        {

            //8187 = too high
            var answer = Day03.Part2(input);
            Assert.AreEqual(2341, answer);
        }
    }


}