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
    public static class Day14
    {
        public static ulong Part1(List<string> input)
        {
            return GetPolymer(input, 10);
        }

        public static ulong Part2(List<string> input)
        {
            return GetPolymer(input, 40);
        }



        private static ulong GetPolymer(List<string> input, int iterations)
        {
            string polymerTemplate = input.First();
            var pairInsertionRules = input.GetRange(2, input.Count - 2).Select(r => new PairInsertionRule() { Pair = r.Substring(0, 2), Element = r[6] }).ToList();


            Dictionary<char, ulong> chars = new();
            var destinctChars = GetDestinctChars(pairInsertionRules, polymerTemplate);
            foreach (var c in destinctChars)
            {
                chars.Add(c, 0);
            }

            string polymer = polymerTemplate;
            for (int i = 0; i < iterations; i++)
            {
                polymer = UpdatePolymer(polymer, pairInsertionRules);
            }

            foreach (var c in polymer)
            {
                chars[c]++;
            }



            return chars.Values.Max() - chars.Values.Min();
        }

        private static string UpdatePolymer(string polymerTemplate, List<PairInsertionRule> pairInsertionRules)
        {
            string newPlymer = "";
            for (int i = 0; i < polymerTemplate.Length; i++)
            {
                if (i == polymerTemplate.Length - 1)
                {
                    newPlymer += polymerTemplate.Last();
                    break;
                }
                string pair = polymerTemplate.Substring(i, 2);
                var matchingRule = pairInsertionRules.FirstOrDefault(r => r.Pair == pair);
                newPlymer += $"{pair[0]}{matchingRule.Element}";
            }
            return newPlymer;
        }



        private static char[] GetDestinctChars(List<PairInsertionRule> pairInsertionRule, string polymerTemplate)
        {
            string chars = "";
            foreach (var pair in pairInsertionRule)
            {
                chars += pair.Pair;
                chars += pair.Element;
            }
            return chars.Distinct().ToArray();
        }



        public class PairInsertionRule
        {
            public string Pair { get; set; }
            public char Element { get; set; }
        }

    }
}
