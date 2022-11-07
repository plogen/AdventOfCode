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
using System.Collections;

namespace aoc2015
{
    public static class Day10
    {
        public static int Part1(int input)
        {
            var digits = GetDigits(input);

            //var adj = 0;
            //var t = digits.Zip(digits.Skip(1).Concat(new TimeStatus[] { null }),
            //        (x, y) => new { x, key = (x == null || y == null || x.Status == y.Status) ? adj : adj++ }
            //    ).GroupBy(i => i.key, (k, g) => g.Select(e => e.x));

            //var t = digits.GetEnumerator();
            //while (t.MoveNext())
            //{
            //    var current = t.Current;
            //    t.
            //}
            return -1;
        }

        public static int Part2(int input)
        {
            return -1;
        }


        public static IEnumerable<int> GetDigits(int source)
        {
            while (source > 0)
            {
                var digit = source % 10;
                source /= 10;
                yield return digit;
            }
        }


    }
}
