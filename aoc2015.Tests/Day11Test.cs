using Common;
using static aoc2015.Day02;
using static aoc2015.Day07;

namespace aoc2015.Tests
{

    [TestFixture]
    public class TestDay11
    {

        [OneTimeSetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("hijklmmn", false)]
        [TestCase("abbceffg", false)]
        [TestCase("abbcegjk", false)]
        [TestCase("ghjaabcc", true)]
        [TestCase("hxcaabcc", true)]
        public void ExamplePasswordValidation(string input, bool expected)
        {
            var answer = Day11.PasswordValid(input.ToCharArray());
            Assert.AreEqual(expected, answer);
        }

        [Test]
        [TestCase("abcdefgh", "abcdffaa")]
        [TestCase("ghijklmn", "ghjaabcc")]
        //[TestCase("ghijmmaa", "xxxxxxx")]// fake one for testing
        public void ExamplePart1(string input, string expected)
        {
            var answer = Day11.Part1(input);
            Assert.AreEqual(expected, answer);
        }

        [Test]
        [TestCase("hxbxwxba", "hxbxxyzz")]
        public void Part1(string input, string expected)
        {
            var answer = Day11.Part1(input);
            Assert.AreNotEqual("hxccdeff", answer);// Tested so se even if ExamplePart1  [TestCase("ghijklmn", "ghjaabcc")] failed
            Assert.AreEqual(expected, answer);
        }

        [Test]
        [TestCase("hxbxwxba", "hxcaabcc")]
        public void Part2(string input, string expected)
        {
            var answer = Day11.Part2(input);
            Assert.AreEqual(expected, answer);
        }
    }


}