using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Helper
    {
        public static bool IsPositive(this int number)
        {
            return number > 0;
        }

        public static bool IsNegative(this int number)
        {
            return number < 0;
        }

        public static bool IsZero(this int number)
        {
            return number == 0;
        }


        public static bool IsAllIncreasing(this int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] >= numbers[i + 1])
                    return false;
            }
            return true;
        }

        public static bool IsAllDecreasing(this int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] <= numbers[i + 1])
                    return false;
            }
            return true;
        }

        public static bool IsWithinSteps(this int[] numbers, int allowedStepSize)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (Math.Abs(numbers[i] - numbers[i + 1]) > allowedStepSize)
                    return false;
            }
            return true;
        }



        public static readonly Dictionary<char, Func<long, long, long>> Operators = new ()
        {
            {'+', (x,y) => x+y},
            {'-', (x,y) => x-y},
            {'*', (x,y) => x*y},
            {'/', (x,y) => x/y}
        };


        public static readonly Dictionary<string, int> NumbersAsText = new()
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
        };

        public static int GetNumber(string input)
        {
            if (int.TryParse(input, out var result))
            {
                return result;
            }
            return NumbersAsText[input];
        }


        public static (int X, int Y) SearchArray(int search, int[,] array)
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    if (array[x, y] == search)
                    {
                        return (X: x, Y: y);
                    }
                }
            }
            return (-1, -1);
        }




        public static string GetSolutionDir()
        {
            string solutionDir = string.Empty;
            #if DEBUG
                solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            #else
                solutionDir = Environment.CurrentDirectory;
            #endif
            return solutionDir;
        }

    }
}
