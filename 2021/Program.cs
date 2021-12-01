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
    var inputPart1 = ReadInputFile.GetInput(1).ToArray();
    stopwatch.Restart();
    var answer = Day1.Part1(inputPart1);
    stopwatch.Stop();
    PrintResult(1, answer, stopwatch.Elapsed);
}


static void PrintResult(int part, object answer, TimeSpan executionTime)
{
    Console.WriteLine($"Part {part} answer: {answer} was fount in {executionTime.TotalMilliseconds} ms");
}



Console.ReadLine();