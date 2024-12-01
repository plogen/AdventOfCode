using Common;
using System.Text;
using System.Text.RegularExpressions;

//Puzzle: https://adventofcode.com/2024/day/1
namespace aoc2024;
public class Day01: DayPuzzle
{
    public override object Part1(List<string> input)
    {
        var list = GetList(input);
        var totalDistance = GetTotalDistance(list);
        return totalDistance;
    }

    public override object Part2(List<string> input)
    {
        var list = GetList(input);
        var similarityScore = GetSimilarityScore(list);
        return similarityScore;
    }


    private ListInput GetList(List<string> input)
    {
        List<int> left = new List<int>();
        List<int> right = new List<int>();
        foreach (var row in input)
        {
            var values = row.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            left.Add(int.Parse(values[0]));
            right.Add(int.Parse(values[1]));
        }
        return new ListInput(left, right);
    }

    private long GetTotalDistance(ListInput listInput)
    {
        long totalDistance = 0;
        listInput.left.Sort();
        listInput.right.Sort();

        for (int i = 0; i < listInput.left.Count; i++)
        {
            totalDistance += Math.Abs(listInput.right[i] - listInput.left[i]);
        }

        return totalDistance;
    }

    private long GetSimilarityScore(ListInput listInput)
    {
        long similarityScore = 0;

        foreach (var left in listInput.left)
        {
            similarityScore += left * listInput.right.Count(x => x == left);
        }

        return similarityScore;
    }


    record ListInput(List<int> left, List<int> right);

}