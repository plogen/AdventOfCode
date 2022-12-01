using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2022
{
    public static class Day01
    {
        public static long Part1(List<string> input)
        {
            return GetCallories(input).OrderByDescending(n => n).First();
        }

        public static long Part2(List<string> input)
        {
            return GetCallories(input).OrderByDescending(n => n).Take(3).Sum();
        }

        public static List<long> GetCallories(List<string> input)
        {
            List<long> elfCalories = new List<long>();

            long calories = 0;
            foreach (var niss in input)
            {
                if (string.IsNullOrEmpty(niss))
                {
                    elfCalories.Add(calories);
                    calories = 0;
                    continue;
                }
                calories += long.Parse(niss);
            }

            return elfCalories;
        }



    }
}
