using Common;

//Puzzle: https://adventofcode.com/2024/day/2
namespace aoc2024;
public class Day02: DayPuzzle
{
    public override object Part1(List<string> input)
    {
        var reports = GetReports(input);

        foreach (var report in reports)
        {
            var isSafe = IsSafe(report);
        }

        return reports.Where(r => IsSafe(r)).Count();
    }

    public override object Part2(List<string> input)
    {
        throw new NotImplementedException();
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

}