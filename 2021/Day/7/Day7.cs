using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2021
{
    public static class Day7
    {
        public static int Part1(List<int> input)
        {
            var min = input.Min();
            var max = input.Max();
            var results = new Dictionary<int, int>();
            for (int i = min; i <= max; i++)
            { 
                int cost = 0;
                foreach (var crab in input)
                {
                    if(crab < i)
                        cost += (i - crab);
                    else if (crab > i)
                        cost += (crab - i);
                }
                results.Add(i, cost);
            }
            return results.Min(r => r.Value);
        }


        public static int Part2(List<int> input)
        {
            var min = input.Min();
            var max = input.Max();
            var results = new Dictionary<int, int>();
            for (int i = min; i <= max; i++)
            {
                int cost = 0;
                foreach (var crab in input)
                {
                    int diff = 0;
                    if (crab < i)
                        diff = (i - crab);
                    else if (crab > i)
                        diff = (crab - i);

                    for (int x = 1; x <= diff; x++)
                    {
                        cost += x;
                    }

                }
                results.Add(i, cost);
            }
            return results.Min(r => r.Value);

        }

    }
}
