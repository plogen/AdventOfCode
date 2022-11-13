using Common;
using static aoc2015.Day02;
using static aoc2015.Day07;

namespace aoc2015.Tests
{

    [TestFixture]
    public class TestDay14
    {
        private readonly int day = 14;
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
            var answer = Day14.Part1(exampleInput, 1000);
            Assert.AreEqual(1120, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day14.Part1(input, 2503);
            Assert.AreEqual(2640, answer);
        }


        [Test]
        public void ExamplePart2()
        {
            var answer = Day14.Part2(exampleInput, 1000);
            Assert.AreEqual(689, answer);
        }


        [Test]
        public void Part2()
        {
            var answer = Day14.Part2(input, 2503);
            Assert.AreEqual(1102, answer);
        }
    }


}