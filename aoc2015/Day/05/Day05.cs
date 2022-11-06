using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static aoc2015.Day03;

namespace aoc2015
{
    public static class Day05
    {


        public static bool IsNice(string input)
        {
            //It does not contain the strings ab, cd, pq, or xy, even if they are part of one of the other requirements.
            if (ContainsNaughtyStrings(input))
                return false;

            //It contains at least three vowels (aeiou only), like aei, xazegov, or aeiouaeiouaeiou.
            if (VowelsCount(input) < 3)
                return false;

            //It contains at least one letter that appears twice in a row, like xx, abcdde (dd), or aabbccdd (aa, bb, cc, or dd).
            if (HasRepeatedCharacters(input) == false)
                return false;

            return true;
        }

        public static int VowelsCount(string input)
        {
            char[] vowelChars = "aeiou".ToCharArray();
            int foundVowels = 0;
            foreach (var c in vowelChars)
            {
                foundVowels += input.Count(s => s == c);
            }
            return foundVowels;
        }

        public static bool ContainsNaughtyStrings(string input)
        {
            string[] naughtyStrings = new string[] { "ab", "cd", "pq", "xy" };

            foreach (var naughty in naughtyStrings)
            {
                if (input.Contains(naughty))
                    return true;
            }
            return false;
        }

        public static bool HasRepeatedCharacters(string input)
        {
            bool hasRepeatedCharacters = false;

            if (input.Length >= 2)
            {
                for (var index = 0; index < input.Length - 1; index++)
                {
                    if (input[index] == input[index + 1])
                    {
                        hasRepeatedCharacters = true;
                    }
                }
            }
            return hasRepeatedCharacters;
        }




        public static int Part1(List<string> inputs)
        {
            int result = 0;
            foreach (var input in inputs)
            {
                if (IsNice(input))
                    result++;
            }
            //input.ForEach(s => IsNice(s) == true ? result++ : null);
            return result;
        }


        public static bool TwoLetterTwice(string input)
        {
            //It contains a pair of any two letters that appears at least twice in the string without overlapping,
            //like xyxy(xy) or aabcdefgaa(aa),
            //but not like aaa(aa, but it overlaps).
            var pairs = new HashSet<string>();
            List<string> pairsDebug = new List<string>();


            bool lastWasANewPair = false;
            for (var index = 0; index < input.Length - 1; index++)
            {
                string pair = input.Substring(index, 2);
                if (pairs.Contains(pair))
                {
                    if (lastWasANewPair) //Catches overlapping
                    {
                        if(pair == pairs.Last())
                            return false;
                    }

                    pairsDebug.Add(pair);
                    return true;
                }
                else
                {
                    pairs.Add(pair);
                    lastWasANewPair = true;
                    continue;
                }
                lastWasANewPair = false;
            }

            return false;
        }

        public static bool HasRepetingCharWithOneSteppInbetween(string input)
        {
            //at least one letter which repeats with exactly one letter between them, like xyx, abcdefeghi (efe), or even aaa.
            for (var i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == input[i+2])
                { 
                    return true; 
                }
            }
            return false;
        }




        public static int Part2(List<string> inputs)
        {
            int niceStrings = 0;
            foreach (var input in inputs)
            {
                if (HasRepetingCharWithOneSteppInbetween(input) == false)
                    continue;

                if (TwoLetterTwice(input) == false)
                    continue;

                niceStrings++;
            }
            return niceStrings;
        }


    }
}
