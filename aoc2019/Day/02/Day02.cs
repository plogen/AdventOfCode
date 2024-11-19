using Common;

//Puzzle: https://adventofcode.com/2019/day/2
namespace aoc2019;
public class Day02: DayPuzzle
{
    public override object Part1(List<string> input)
    {
        var ints = input.First().Split(',').Select(Int32.Parse).ToList();

        //reproduce 1202 program alarm
        ints[1] = 12;
        ints[2] = 2;

        bool terminated = false;
        int index = 0;
        while(!terminated)
        {
            terminated = Calculator(ints, index);
            index += 4;
        }

        return ints[0];
        
    }

    public override object Part2(List<string> input)
    {
        throw new NotImplementedException();
    }


    private bool Calculator(List<int> ints, int index)
    {
        var opcode = ints[index];
        if (opcode == 99)
        {
            return true;
        }
        if (opcode == 1)
        {
            var value = ints[ints[index + 1]] + ints[ints[index + 2]];
            ints[ints[index + 3]] = value;
            return false;
        }
        if (opcode == 2)
        {
            var value = ints[ints[index + 1]] * ints[ints[index + 2]];
            ints[ints[index + 3]] = value;
            return false;
        }

        throw new InvalidOperationException("Unhandled opcode");
    }

}