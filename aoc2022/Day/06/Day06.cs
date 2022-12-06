using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2022
{
    public static class Day06
    {
        public static int Part1(string input)
        {
            return GetStartOfMessage(input, 4);
        }

        public static int Part2(string input)
        {
            return GetStartOfMessage(input, 14);
        }




        private static int GetStartOfMessage(string input, int sequenzeCount)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input.Substring(i, sequenzeCount).Distinct().Count() == sequenzeCount)
                {
                    return i + sequenzeCount;
                }
            }
            throw new Exception("Invalid evaluation");
        }

    }
}
