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
using MoreLinq;

namespace aoc2015
{
    public static class Day10
    {
        public static string Part1(string input)
        {
            //Brute force going through each iteration, gets exponentionally more data and processing time as iteration increaeases
            var data = input;
            for (int i = 0; i < 40; i++)
            {
                var repeatedCharGroups = GetRepeatedCharGroups(data);
                data = LookAndSay(repeatedCharGroups);
            }
            return data;
        }

        public static List<List<char>> GetRepeatedCharGroups(string input)
        {
            var charGroups = new List<List<char>>();
            var lastHandledChar = '!';
            foreach (var c in input)
            {
                if (lastHandledChar == '!' || c != lastHandledChar)
                {
                    charGroups.Add(new List<char>() { c });
                }
                else
                {
                    charGroups.Last().Add(c);
                }
                lastHandledChar = c;
            }
            return charGroups;
        }

        public static string LookAndSay(List<List<char>> repeatedChars)
        {
            string lookAndSay = "";
            foreach (var repeat in repeatedChars)
            {
                lookAndSay += $"{repeat.Count}{repeat[0]}";
            }
            return lookAndSay;
        }


        public static int Part2(string input)
        {

            var test = input.Select(c => c - '0').ToArray();

            var result = Enumerable.Range(1, 50)
                .Aggregate(input.Select(c => c - '0').ToArray(), //Convert chars to int[] and use as TSource
                   (accumulated, _) => //An accumulator function to be invoked on each element.
                 accumulated.GroupAdjacent(n => n)
                .SelectMany(g => new int[] { g.Count(), g.First() })
                .ToArray())
                .Count(); //A function to transform the final accumulator value into the result value.
            return result;
        }




    }
}
