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

        return Calculate(ints);

    }

    public override object Part2(List<string> input)
    {
        var orgInputs = input.First().Split(',').Select(Int32.Parse).ToList();
        var ints = new List<int>(orgInputs);

        while (true)
        {
            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    ints[1] = noun;
                    ints[2] = verb;
                    Calculate(ints);

                    if (ints[0] == 19690720)
                    {
                        return 100 * noun + verb;
                    }
                    else
                    {
                        ints = new List<int>(orgInputs);
                    }
                }
            }
        }
    }


    private int Calculate(List<int> ints)
    {
        bool terminated = false;
        int index = 0;
        while (!terminated)
        {
            terminated = UpdateValues(ints, index);
            index += 4;
        }

        return ints[0];
    }

    private bool UpdateValues(List<int> ints, int index)
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