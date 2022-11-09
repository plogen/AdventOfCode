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
using System.Collections;

namespace aoc2015
{
    public static class Day11
    {
        public static string Part1(string input)
        {
            var password = input.ToArray();
            while (PasswordValid(password) == false)
            {
                IncrementPassword(password);
            }

            return new string(password);
        }

        public static string Part2(string input)
        {
            var password = input.ToArray();

            int experationCount = 2;
            int generatedPasswords = 0;
            while (generatedPasswords != experationCount)
            {
                IncrementPassword(password);
                if (PasswordValid(password))
                    generatedPasswords++;
            }

            return new string(password);
        }





        private static void IncrementPassword(char[] password)
        {
            for (int i = password.Length - 1; i >= 0; i--)
            {
                if (password[i] == 'z')
                {
                    password[i] = 'a';
                }
                else
                {
                    password[i]++;
                    if (password[i] is 'i' or 'o' or 'l')
                    {
                        password[i]++;
                    }
                    break;
                }
            }
        }













        public static bool PasswordValid(char[] input) 
        {
            if (HasIncrementingChars(input) == false)
                return false;

            if (HaslligalChars(input))
                return false;

            if(HasAtLeast2differentNonOverlappingPairs(input) == false)
                return false;

            return true;
        }

        public static bool HaslligalChars(char[] input)
        {
            char[] illegalChars = { 'i', 'o', 'l'};
            if (input.Any(c => illegalChars.Contains(c)))
            {
                return true;
            }
            return false; 
        }

        public static bool HasAtLeast2differentNonOverlappingPairs(char[] input)
        {
            var repeatedChars = new HashSet<char>();
            if (input.Length >= 2)
            {
                for (var index = 0; index < input.Length - 1; index++)
                {
                    if (input[index] == input[index + 1])
                    {
                        repeatedChars.Add(input[index]);
                    }
                }
            }

            if (repeatedChars.Count >= 2)
                return true;
            else
                return false;

        }
        public static bool HasIncrementingChars(char[] input)
        {
            int inArow = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if ((input[i + 1] - input[i]) == 1)
                    inArow++;
                else
                    inArow = 0;

                if(inArow == 2)
                    return true;
            }
            return false;
        }




    }
}
