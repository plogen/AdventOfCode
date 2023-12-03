using Common;
using System.Text.RegularExpressions;

//Puzzle: https://adventofcode.com/2023/day/3
namespace aoc2023
{
    public class Day03: DayPuzzle
    {
        public static Regex numberRegex = new Regex(@"(\d+)");
        public static Regex symbolRegex = new Regex(@"[^.0-9\.]");
        public override object Part1(List<string> input)
        {
            List<int> partNumbers = new();

            for (int i = 0; i < input.Count; i++)
            {
                var numbers = numberRegex.Matches(input[i]);

                foreach (Match number in numbers)
                {
                    List<string> areas = new();

                    string upperArea = null;
                    if (i > 0)
                    {
                        int start = 0;
                        if (number.Index != 0)
                            start = number.Index - 1;

                        int end = 0;
                        if (number.Index + number.Length != input[i].Length)
                            end = number.Length + (number.Index == 0 ? 1 : 2);
                        else
                            end = number.Length;

                        upperArea = input[i - 1].Substring(start, end);
                        areas.Add(upperArea);
                    }


                    string lowerArea = null;
                    if ((i + 1) < input.Count)
                    {
                        int start = 0;
                        if (number.Index != 0)
                            start = number.Index - 1;

                        int end = 0;
                        if (number.Index + number.Length != input[i].Length)
                            end = number.Length + (number.Index == 0 ? 1 : 2);
                        else
                            end = number.Length;

                        lowerArea = input[i+1].Substring(start, end);
                        areas.Add(lowerArea);
                    }

                    string leftArea = null;
                    if (number.Index > 0)
                    {
                        leftArea = input[i].Substring(number.Index-1, 1);
                        areas.Add(leftArea);
                    }

                    string rightArea = null;
                    if (number.Index + number.Length < input[i].Length)
                    {
                        rightArea = input[i].Substring(number.Index + number.Length, 1);
                        areas.Add(rightArea);
                    }

                    if(areas.Any(a => symbolRegex.Match(a).Success))
                        partNumbers.Add(int.Parse(number.Value));

                }
            }


            return partNumbers.Sum();
        }

        public override object Part2(List<string> input)
        {
            throw new NotImplementedException();
        }
    }
}