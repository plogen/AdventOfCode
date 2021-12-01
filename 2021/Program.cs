// See https://aka.ms/new-console-template for more information
using aoc2021;
using Common;
using System.Diagnostics;

int day = 0;
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
    Console.WriteLine("--- Day 1: Sonar Sweep ---");
    var input = ReadInputFile.GetInput(1, "input.txt").ToArray();
    stopwatch.Restart();
    var answerPart1 = Day1.Part1(input);
    stopwatch.Stop();
    PrintResult(1, answerPart1, stopwatch.Elapsed);

    stopwatch.Restart();
    var answerPart2 = Day1.Part2(input);
    stopwatch.Stop();
    PrintResult(1, answerPart2, stopwatch.Elapsed);

}


static void PrintResult(int part, object answer, TimeSpan executionTime)
{
    Console.WriteLine($"Part {part} answer: {answer} was fount in {executionTime.TotalMilliseconds} ms");
}



Console.ReadLine();