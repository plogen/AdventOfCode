using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static aoc2015.Day03;
using static aoc2015.Day07;

namespace aoc2015
{
    public static class Day08
    {
        public static int Part1(List<string> inputs)
        {
            int readableCharsCount = 0;
            int totChars = 0;

            foreach (var input in inputs)
            {
                var unescape = Regex.Unescape(input.Substring(1, input.Length - 2));
                readableCharsCount += input.Length;
                totChars += unescape.Length;
            }
            return readableCharsCount - totChars;
        }

        public static int Part2(List<string> inputs)
        {
            int readableCharsCount = 0;
            int totChars = 0;

            foreach (var input in inputs)
            {
                readableCharsCount += input.Length;
                var t = "\"" + input.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
                totChars += t.Length;
            }
            return totChars - readableCharsCount;
        }

    }
}
