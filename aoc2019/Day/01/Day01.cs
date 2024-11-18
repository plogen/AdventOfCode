using Common;

//Puzzle: https://adventofcode.com/2019/day/1
namespace aoc2019;
public class Day01 : DayPuzzle
{
    public override object Part1(List<string> input)
    {
        return input.Select(Int32.Parse)
            .Sum(m => CalulateFuel(m));
    }

    public override object Part2(List<string> input)
    {
        var modules = input.Select(Int32.Parse);

        int sum = 0;
        foreach (var module in modules)
        {
            var fuel = CalulateFuel(module);
            sum += fuel;

            while (fuel >= 0)
            {
                var fuleForFule = CalulateFuel(fuel);
                if (fuleForFule > 0)
                {
                    sum += fuleForFule;
                    fuel = fuleForFule;
                }
                else
                    break;
            }
        }
        return sum;
    }

    private static int CalulateFuel(int input)
    {
        return (int)Math.Floor(input / 3d) - 2;
    }

    private static int CalulateFuelForFule(int input)
    {
        var sum = 0;
        return (int)Math.Floor(input / 3d) - 2;
    }
}