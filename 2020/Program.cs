using _2020.Day1;
using _2020.Day2;
using _2020.Day3;
using System;
using System.Diagnostics;

namespace _2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = 3;
            int part = 0;
            if (args.Length == 1)
            {
                day = int.Parse(args[0]);
            }
            else if (args.Length == 2)
            {
                day = int.Parse(args[0]);
                part = int.Parse(args[1]);
            }

            var stopwatch = Stopwatch.StartNew();

            if (day is 0 or 1)
            {
                Console.WriteLine("--- Day 1: Report Repair ---");
                var input = FindExpenceError.GetInput();
                var answer = FindExpenceError.GetAnswerPart1v1(input);
                stopwatch.Restart();
                Console.WriteLine($"The answer is: {answer} was fount in {stopwatch.Elapsed} ms");
                stopwatch.Restart();
                var answer2 = FindExpenceError.GetAnswerPart1v2(input);
                stopwatch.Stop();
                Console.WriteLine($"The answer is: {answer2} was fount in {stopwatch.Elapsed} ms");
            }


            if (day is 0 or 2)
            {
                Console.WriteLine("--- Day 2: Password Philosophy ---");
                var day2Input = ValidatePasswords.GetInput();
                stopwatch.Restart();
                var day2answer = ValidatePasswords.ValidPasswords(day2Input);
                stopwatch.Stop();
                Console.WriteLine($"The answer is: {day2answer} was fount in {stopwatch.Elapsed} ms");

            }


            if (day is 0 or 3)
            {
                Console.WriteLine("--- Day 3: Toboggan Trajectory ---");
                var day3Input = Trajectory.GetInput();
                stopwatch.Restart();
                var day3answer1 = Trajectory.GetCrashes(day3Input, new Trajectory.Slope() { X = 3, Y = 1 });
                stopwatch.Restart();
                Console.WriteLine($"The answer is: {day3answer1} was fount in {stopwatch.Elapsed} ms");
                var day3answer2 = Trajectory.GetMultiSlopeCrashes(day3Input, 
                    new System.Collections.Generic.List<Trajectory.Slope>()
                    {
                        { new Trajectory.Slope() { X = 1, Y = 1 } },
                        { new Trajectory.Slope() { X = 3, Y = 1 } },
                        { new Trajectory.Slope() { X = 5, Y = 1 } },
                        { new Trajectory.Slope() { X = 7, Y = 1 } },
                        { new Trajectory.Slope() { X = 1, Y = 2 } }
                    });
                stopwatch.Stop();
                Console.WriteLine($"The answer is: {day3answer2} was fount in {stopwatch.Elapsed} ms");
            }



        }
    }
}
