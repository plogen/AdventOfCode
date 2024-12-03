using Common;
using System.Text.RegularExpressions;

//Puzzle: https://adventofcode.com/2024/day/3
namespace aoc2024;
public class Day03: DayPuzzle
{
    public override object Part1(List<string> input)
    {
        var numbers = GetNumbers(input);
        return GetResult(numbers);
    }

    public override object Part2(List<string> input)
    {
        for (var i = 0; i < input.Count; i++)
        {
            var lastDont = input[i].LastIndexOf("don't()");
            var lastDo = input[i].LastIndexOf("do()");
            if (lastDont > lastDo)
            {
                input[i] = input[i].Substring(0, lastDont + 7);
            }
        }

        var removed = input.Select(x => Helper.RemoveBetween(x, "don't()", "do()")).ToList();

        var numbers = GetNumbers(removed);
        return GetResult(numbers);
    }


    private long GetResult(List<Tuple<int, int>> numbers)
    {
        return numbers.Select(x => x.Item1 * x.Item2).Sum();
    }

    private List<Tuple<int, int>> GetNumbers(List<string> input)
    {
        var list = new List<Tuple<int, int>>();
        foreach (var row in input)
        {
            list.AddRange(Regex.Matches(row, @"mul\((\d{1,4}),(\d{1,4})\)")
                .Select(x => new Tuple<int, int>( int.Parse(x.Groups[1].Value), int.Parse(x.Groups[2].Value)))
                .ToList());

        }
        return list;
    }


}