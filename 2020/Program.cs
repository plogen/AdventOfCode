using _2020.Day1;
using System;

namespace _2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Day 1: Report Repair ---");
            var input = FindExpenceError.GetInput();
            var answer = FindExpenceError.GetAnswer(input);
            Console.WriteLine($"The answer is: {answer}");

            var answer2 = FindExpenceError.GetAnswer2(input);
            Console.WriteLine($"The answer2 is: {answer2}");
        }
    }
}
