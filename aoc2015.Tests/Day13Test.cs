using Common;
using static aoc2015.Day02;
using static aoc2015.Day07;

namespace aoc2015.Tests
{

    [TestFixture]
    public class TestDay13
    {
        private readonly int day = 13;
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
            var answer = Day13.Part1(exampleInput);
            Assert.AreEqual(330, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day13.Part1(input);
            Assert.AreEqual(733, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day13.Part2(input);
            Assert.AreEqual(725, answer);
        }
    }


}