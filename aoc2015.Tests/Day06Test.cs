using Common;
using static aoc2015.Day02;

namespace aoc2015.Tests
{

    [TestFixture]
    public class TestDay06
    {
        private readonly int day = 6;
        private List<string> input = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(day, "input.txt");
        }

        [Test]
        [TestCase("turn on 0,0 through 999,999", 1000000)]
        [TestCase("toggle 0,0 through 999,0", 1000)]
        public void ExamplePart1(string input, int expected)
        {
            var answer = Day06.Part1(new List<string>() { input });
            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day06.Part1(input);
            Assert.AreEqual(377891, answer);
        }


        [Test]
        [TestCase("turn on 0,0 through 0,0", 1)]
        [TestCase("toggle 0,0 through 999,999", 2000000)]
        public void ExamplePart2(string input, int expected)
        {
            var answer = Day06.Part2(new List<string> { input });
            Assert.AreEqual(expected, answer);
        }


        [Test]
        public void Part2()
        {
            var answer = Day06.Part2(input);
            Assert.AreEqual(0, answer);
        }
    }


}