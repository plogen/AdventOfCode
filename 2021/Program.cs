// See https://aka.ms/new-console-template for more information
using aoc2021;
using Common;
using System.Diagnostics;
using static aoc2021.Day11;
using static aoc2021.Day13;

int day = 13;
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
    var input = ReadInputFile.GetInput(1, "input.txt").Select(int.Parse).ToArray();
    stopwatch.Restart();
    var answerPart1 = Day1.Part1(input);
    stopwatch.Stop();
    PrintResult(1, answerPart1, stopwatch.Elapsed);

    stopwatch.Restart();
    var answerPart2 = Day1.Part2(input);
    stopwatch.Stop();
    PrintResult(1, answerPart2, stopwatch.Elapsed);

}


if (day is 0 or 11)
{
    Console.WriteLine("--- Day 11: Dumbo Octopus ---");

    int[][] input = null!;
    int[][] exampleInput = null!;

    var inputRows = ReadInputFile.GetInput(day, "input.txt");
    input = ReadInputFile.GetInputAsMultiArrayInt(inputRows);

    var exampleInputRows = ReadInputFile.GetInput(day, "exampleInput.txt");
    exampleInput = ReadInputFile.GetInputAsMultiArrayInt(exampleInputRows);


    var opctopuses = Day11.GetOctupuses(exampleInput);
    PrintOctupuses(opctopuses);
    for (int i = 1; i <= 10; i++)
    {
        Console.Clear();
        var result = OneFlashRound(opctopuses);
        Console.WriteLine($"After step {i}:");
        PrintOctupuses(opctopuses);
        Thread.Sleep(1000);

    }

}




if (day is 0 or 13)
{
    Console.WriteLine("--- Day 13: Transparent Origami ---");
    List<string> input = ReadInputFile.GetInput(day, "input.txt").ToList();
    List<string> exampleInput = ReadInputFile.GetInput(day, "exampleInput.txt").ToList();
    var paper = Day13.Part2(input);
    PrintTransparentOrigami(paper);
}






static void PrintOctupuses(List<Octopus> octupuses)
{
    foreach (var octupus in octupuses)
    {
        if (octupus.EnergyLevel is 0)
            Console.ForegroundColor = ConsoleColor.Yellow;

        Console.Write(octupus.EnergyLevel);

        if (octupus.EnergyLevel is 0)
            Console.ResetColor();

        if (octupus.X == 9)
            Console.WriteLine();
    }
}


static void PrintTransparentOrigami(Paper paper)
{
    var xSize = paper.Dots.GetLength(0);
    var ySize = paper.Dots.GetLength(1);


    for (int y = 0; y < ySize; y++)
    {
        for (int x = 0; x < xSize; x++)
        {
            Console.SetCursorPosition(x, y);
            if (paper.Dots[x, y] == 1)
                Console.Write('#');
            else
                Console.Write(' ');
        }
    }
}





static void PrintResult(int part, object answer, TimeSpan executionTime)
{
    Console.WriteLine($"Part {part} answer: {answer} was fount in {executionTime.TotalMilliseconds} ms");
}



Console.ReadLine();