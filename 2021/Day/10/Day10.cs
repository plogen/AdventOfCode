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
    public static class Day10
    {


        public static int Part1(List<string> input)
        {
            int result = 0;
            foreach (var row in input)
            {
                result += GetPoints(PushPop(row));
            }
            return result;
        }


        public static long Part2(List<string> input)
        {

            List<long> results = new List<long>();
            foreach (var row in input)
            {
                long score = 0;
                var success = CompleteIncomplete(row, out score);
                if (success)
                    results.Add(score);
            }

            results.Sort();

            return results[results.Count/2];
        }



        public static char PushPop(string row)
        {
            Stack<char> stack = new Stack<char>();
            foreach (var c in row)
            {
                if (c is '(' or '[' or '{' or '<')
                {
                    stack.Push(c);
                    continue;
                }

                var pop = stack.Pop();
                if (c is ')' && pop != '(')
                    return c;
                if (c is ']' && pop != '[')
                    return c;
                if (c is '}' && pop != '{')
                    return c;
                if (c is '>' && pop != '<')
                    return c;

            }
            return '0';
        }


        public static bool CompleteIncomplete(string row, out long score)
        {
            score = 0;

            Stack<char> stack = new Stack<char>();
            foreach (var c in row)
            {
                if (c is '(' or '[' or '{' or '<')
                {
                    stack.Push(c);
                    continue;
                }
                var pop = stack.Pop();
                if (c is ')' && pop != '(')
                {
                    return false;
                    break;
                }
                if (c is ']' && pop != '[')
                {
                    return false;
                    break;
                }
                if (c is '}' && pop != '{')
                {
                    return false;
                    break;
                }
                if (c is '>' && pop != '<')
                {
                    return false;
                    break;
                }
            }
                

            List<char> completed = new List<char>();
            int stackCount = stack.Count;
            for (int i = 0; i < stackCount; i++)
            {
                var pop = stack.Pop();
                if (pop is '(')
                    completed.Add(')');
                if (pop is '[')
                    completed.Add(']');
                if (pop is '{')
                    completed.Add('}');
                if (pop is '<')
                    completed.Add('>');
            }

            foreach (var c in completed)
            {
                score = score * 5;
                score += GetAutocompletePoint(c);
            }
            return true;

        }

        private static int GetAutocompletePoint(char c)
        {
            switch (c)
            {
                case ')':
                    return 1;
                case ']':
                    return 2;
                case '}':
                    return 3;
                case '>':
                    return 4;
                default:
                    return 0;
                    break;
            }
        }




        private static int GetPoints(char c)
        {
            switch (c)
            {
                case ')':
                    return 3;
                case ']':
                    return 57;
                case '}':
                    return 1197;
                case '>':
                    return 25137;
                default:
                    return 0;
                    break;
            }

        }

    }
}
