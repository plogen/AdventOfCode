using Common;
using System.Text.RegularExpressions;

//Puzzle: https://adventofcode.com/2023/day/1
namespace aoc2023
{
    public class Day01: DayPuzzle
    {
        public static Regex numbersRegex = new Regex(@"(\d)");

        public override object Part1(List<string> input)
        {
            return input.Select(x => GetCalibrationValue(x)).Sum();
        }

        public override object Part2(List<string> input)
        {
            throw new NotImplementedException();
        }

        private long GetCalibrationValue(string input)
        {
            var numbers = numbersRegex.Matches(input);
            var value = numbers.First().Value + numbers.Last().Value;
            return long.Parse(value);
        }


    }
}