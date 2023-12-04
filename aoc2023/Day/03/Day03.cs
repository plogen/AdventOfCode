using Common;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

//Puzzle: https://adventofcode.com/2023/day/3
namespace aoc2023
{
    public class Day03 : DayPuzzle
    {
        public static Regex numberRegex = new Regex(@"(\d+)");
        public static Regex symbolRegex = new Regex(@"[^.0-9\.]");
        public static Regex gearRegex = new Regex(@"[*]");
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

                        lowerArea = input[i + 1].Substring(start, end);
                        areas.Add(lowerArea);
                    }

                    string leftArea = null;
                    if (number.Index > 0)
                    {
                        leftArea = input[i].Substring(number.Index - 1, 1);
                        areas.Add(leftArea);
                    }

                    string rightArea = null;
                    if (number.Index + number.Length < input[i].Length)
                    {
                        rightArea = input[i].Substring(number.Index + number.Length, 1);
                        areas.Add(rightArea);
                    }

                    if (areas.Any(a => symbolRegex.Match(a).Success))
                        partNumbers.Add(int.Parse(number.Value));

                }
            }


            return partNumbers.Sum();
        }

        public override object Part2(List<string> input)
        {
            int[,] cordinates = new int[input[0].Length, input.Count];

            for (int y = 0; y < input.Count; y++)
            {
                var numbers = numberRegex.Matches(input[y]);
                foreach (Match number in numbers)
                {
                    for (int x = 0; x < number.Length; x++)
                    {
                        cordinates[number.Index + x, y] = int.Parse(number.Value);
                    }
                }

                var gears = gearRegex.Matches(input[y]);
                foreach (Match gear in gears)
                {
                    cordinates[gear.Index, y] = -1;
                }
            }

            List<int> gearRatio = new();
            for (int x = 0; x < input[0].Length; x++)
            {
                for (int y = 0; y < input.Count; y++)
                {
                    if (cordinates[x, y] == -1) // -1 = gear
                    {
                        List<int> closeCordinates = new();
                        closeCordinates.Add(cordinates[x - 1, y - 1]);
                        closeCordinates.Add(cordinates[x, y - 1]);
                        closeCordinates.Add(cordinates[x + 1, y - 1]);
                        closeCordinates.Add(cordinates[x - 1, y]);
                        closeCordinates.Add(cordinates[x + 1, y]);
                        closeCordinates.Add(cordinates[x - 1, y + 1]);
                        closeCordinates.Add(cordinates[x, y + 1]);
                        closeCordinates.Add(cordinates[x + 1, y + 1]);

                        var distinct = closeCordinates.Distinct().ToList();

                        distinct.RemoveAll(x => x == 0);

                        if (distinct.Count == 2)
                        {
                            gearRatio.Add(distinct[0] * distinct[1]);
                        }
                        else if (distinct.Count > 2)
                        {
                            throw new InvalidOperationException("not expected...");
                        }

                    }
                }
            }

            return gearRatio.Sum();
        }
    }
}