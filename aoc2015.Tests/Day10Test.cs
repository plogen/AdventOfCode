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
        [TestCase("1", "11")]
        [TestCase("11", "21")]
        [TestCase("21", "1211")]
        [TestCase("1211", "111221")]
        [TestCase("111221", "312211")]
        public void ExamplePart1(string input, string expected)
        {
            var repeatedCharGroups = Day10.GetRepeatedCharGroups(input);
            Assert.AreEqual(expected, Day10.LookAndSay(repeatedCharGroups));
        }

        [Test]
        [TestCase("1321131112", 492982)]
        public void Part1(string input, int expected)
        {
            var answer = Day10.Part1(input);
            Assert.AreEqual(expected, answer.Length);
        }

        [Test]
        [TestCase("1321131112", 6989950)]
        public void Part2(string input, int expected)
        {
            var answer = Day10.Part2(input);
            Assert.AreEqual(expected, answer);
        }
    }


}