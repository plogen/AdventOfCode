using Common;

//Puzzle: https://adventofcode.com/2024/day/2
namespace aoc2024;
public class Day02: DayPuzzle
{
    public override object Part1(List<string> input)
    {
        var reports = GetReports(input);
        return reports.Where(r => IsSafe(r)).Count();
    }

    public override object Part2(List<string> input)
    {
        var reports = GetReports(input);

        int safeReports = 0;
        foreach (var report in reports)
        {
            var isSafe = IsSafe(report);
            if(isSafe)
            {
                safeReports++;
            }
            else
            {
                var permutations = Algorithms.GetPermutationsByRemovingEachposition(report);
                if (permutations.Any(p => IsSafe(p)))
                {
                    safeReports++;
                }
            }
        }

        return safeReports;
    }

    private List<int[]> GetReports(List<string> input)
    {
        var reports = new List<int[]>();

        foreach (var row in input)
        {
            reports.Add(row.Split(' ').Select(int.Parse).ToArray());
        }

        return reports;
    }

    private bool IsSafe(int[] report)
    {
        if(!report.IsAllIncreasing() && !report.IsAllDecreasing())
            return false;

        if(!report.IsWithinSteps(3))
            return false;

        return true;
    }

    private bool IsSafe(int[] report, int allowFaults)
    {
        if (!IsAllIncreasing(report) && !IsAllDecreasing(report))
            return false;

        if (!IsWithinSteps(report, 3))
            return false;

        return true;
    }


    private bool IsAllIncreasing(int[] numbers)
    {
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] >= numbers[i + 1])
            {
                if(i + 2 < numbers.Length && numbers[i] >= numbers[i + 2])
                    return false;
            }
        }
        return true;
    }


    private bool IsAllDecreasing(int[] numbers)
    {
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] <= numbers[i + 1])
            {
                if (i + 2 < numbers.Length && numbers[i] <= numbers[i + 2])
                    return false;
            }
        }
        return true;
    }


    private bool IsWithinSteps(int[] numbers, int allowedStepSize)
    {
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (Math.Abs(numbers[i] - numbers[i + 1]) > allowedStepSize)
            {
                if (i + 2 < numbers.Length && Math.Abs(numbers[i] - numbers[i + 2]) > allowedStepSize)
                    return false;
            }                
        }
        return true;
    }



}