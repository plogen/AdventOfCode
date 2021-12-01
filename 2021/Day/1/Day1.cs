using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    public static class Day1
    {
        public static int Part1(int[] input)
        {
            return HowManyIncriments(input);
        }

        public static int Part2(int[] input)
        {
            var windows = ThreeMeasurementSlidingWindow(input);
            return HowManyIncriments(windows.ToArray());
        }


        private static int HowManyIncriments(int[] input)
        {
            int result = 0;
            for (int i = 1; i < input.Length; i++) //Start at index 1 due to not compare first
            {
                if (input[i] > input[i - 1])
                    result++;
            }
            return result;
        }

        private static List<int> ThreeMeasurementSlidingWindow(int[] input)
        {
            int windowSize = 3;
            List<int> result = new List<int>();
            for (int i = 0; i < input.Length; i++) //Start at index 0 as this method only extracts windows
            {
                if ((input.Length - i) < windowSize) //Stop when not a complete window can combined
                    break;

                result.Add(input[i] + input[i + 1] + input[i + 2]);
            }
            return result;
        }


    }
}
