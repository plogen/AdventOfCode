using Common;

//Puzzle: https://adventofcode.com/2019/day/1
namespace aoc2019;
public class Day01: DayPuzzle
{
    public override object Part1(List<string> input)
    {
        return input.Select(Int32.Parse)
            .Sum(m => (int)Math.Floor(m / 3d) - 2);
    }

    public override object Part2(List<string> input)
    {
        throw new NotImplementedException();
    }
}