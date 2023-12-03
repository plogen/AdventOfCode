using Common;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

//Puzzle: https://adventofcode.com/2023/day/1
namespace aoc2023
{
    public class Day01: DayPuzzle
    {
        public static Regex numbersRegex = new Regex(@"(\d)");
        public static Regex firstRegex = new Regex(@"\d|one|two|three|four|five|six|seven|eight|nine");
        public static Regex lastRegex = new Regex(@"\d|one|two|three|four|five|six|seven|eight|nine", RegexOptions.RightToLeft);

        public override object Part1(List<string> input)
        {
            return input.Select(x => GetCalibrationValue(x)).Sum();
        }

        public override object Part2(List<string> input)
        {
            return input.Select(x => GetCalibrationValueMixed(x)).Sum();
        }

        private long GetCalibrationValue(string input)
        {
            var numbers = numbersRegex.Matches(input);
            var value = numbers.First().Value + numbers.Last().Value;
            return long.Parse(value);
        }


        private long GetCalibrationValueMixed(string input)
        {
            
            var first = firstRegex.Match(input);
            var last = lastRegex.Match(input);

            string value = "";
            value += Helper.GetNumber(first.Value);
            value += Helper.GetNumber(last.Value);
            return long.Parse(value);
        }


    }
}