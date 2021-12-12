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


        public static int Part2(List<string> input)
        {

            int result = 0;
            foreach (var row in input)
            {
                if (PushPop(row) == '0')
                { 
                    
                }
            }

            return 0;
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


        public static char CompleteIncomplete(string row)
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
