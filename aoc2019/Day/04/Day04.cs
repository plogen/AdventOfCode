﻿using Common;

//Puzzle: https://adventofcode.com/2019/day/4
namespace aoc2019;
public class Day04: DayPuzzle
{
    public override object Part1(List<string> input)
    {
        var range = input[0].Split('-').Select(Int32.Parse);
        
        var size = range.Last() - range.First();

        int passwordCount = 0;
        var value = range.First();
        for (int i = 0; i < size; i++)
        {
            if (Increasing(value) && HasDouble(value))
                passwordCount++;

            value++;
        }

        return passwordCount;
    }

    public override object Part2(List<string> input)
    {
        var range = input[0].Split('-').Select(Int32.Parse);

        var size = range.Last() - range.First();

        int passwordCount = 0;
        var value = range.First();
        for (int i = 0; i < size; i++)
        {
            if (Increasing(value) && HasDoubleThatIsNotPartOfLargeGroup(value))
                passwordCount++;

            value++;
        }

        return passwordCount;
    }

    private bool Increasing(int value)
    {
        var array = GetIntArray(value);
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i+1])
            {
                return false;
            }
        }
        return true;
    }

    private bool HasDouble(int value)
    {
        var array = GetIntArray(value);
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] == array[i + 1])
            {
                return true;
            }
        }
        return false;
    }

    private bool HasDoubleThatIsNotPartOfLargeGroup(int value)
    {
        var array = GetIntArray(value);
        List<int> potentialDouble = new();
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] == array[i + 1])
            {
                if(i > 0 && array[i-1] == array[i])
                    continue;
                if (i < array.Length -2 && array[i + 2] == array[i])
                    continue;

                return true;
            }
        }

        return false;
    }




    int[] GetIntArray(int num)
    {
        List<int> listOfInts = new List<int>();
        while (num > 0)
        {
            listOfInts.Add(num % 10);
            num = num / 10;
        }
        listOfInts.Reverse();
        return listOfInts.ToArray();
    }
}