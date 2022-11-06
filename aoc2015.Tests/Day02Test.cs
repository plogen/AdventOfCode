using Common;
using static aoc2015.Day02;

namespace aoc2015.Tests
{

    [TestFixture]
    public class TestDay02
    {
        private readonly int day = 2;
        private List<string> input = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(day, "input.txt");
        }

        [Test]
        [TestCase("2x3x4", 58)]
        [TestCase("1x1x10", 43)]
        public void ExamplePart1(string input, int expected)
        {
            var boxes = new List<Box>() { Day02.GetBox(input) };
            var answer = Day02.Part1(boxes);
            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Part1()
        {
            var boxes = input.Select(i => GetBox(i)).ToList();
            var answer = Day02.Part1(boxes);
            Assert.AreEqual(1586300, answer);
        }


        [Test]
        [TestCase("2x3x4", 34)]
        [TestCase("1x1x10", 14)]
        public void ExamplePart2(string input, int expected)
        {
            var boxes = new List<Box>() { Day02.GetBox(input) };
            var answer = Day02.Part2(boxes);
            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Part2()
        {
            var boxes = input.Select(i => GetBox(i)).ToList();
            var answer = Day02.Part2(boxes);
            Assert.AreEqual(3737498, answer);
        }
    }


}