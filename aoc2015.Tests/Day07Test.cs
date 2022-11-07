using Common;
using static aoc2015.Day02;
using static aoc2015.Day07;

namespace aoc2015.Tests
{

    [TestFixture]
    public class TestDay07
    {
        private readonly int day = 7;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(day, "input.txt");
            exampleInput = ReadInputFile.GetInputDayPadding(day, "exampleInput.txt");
        }

        [Test]
        [TestCase("d", 72)]
        [TestCase("e", 507)]
        [TestCase("f", 492)]
        [TestCase("g", 114)]
        [TestCase("h", 65412)]
        [TestCase("i", 65079)]
        [TestCase("x", 123)]
        [TestCase("y", 456)]
        public void ExamplePart1(string wire, int expected)
        {
            var wires = Day07.Part1(exampleInput);
            Assert.AreEqual(expected, wires.First(w => w.Name == wire).Value);
        }



        [Test]
        public void Part1()
        {
            var wires = Day07.Part1(input);
            Assert.AreEqual(46065, wires.First(w => w.Name == "a").Value);
        }


        [Test]
        public void Part2()
        {
            var answer = Day07.Part2(input);
            Assert.AreEqual(14134, answer);
        }
    }


}