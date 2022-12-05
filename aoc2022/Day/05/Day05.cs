using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2022
{
    public static class Day05
    {

        //public static Regex stackContentRegex = new Regex(@"([A-Z])\]");
        public static Regex moveRegex = new Regex(@"move (\d+) from (\d+) to (\d+)");


        public static string Part1(List<string> input)
        {
            var stacks = GetStacks(input);
            var moves = GetMoves(input);
            MoveCratesCrateMover9000(stacks, moves);
            return GetTopCrates(stacks);
        }

        public static string Part2(List<string> input)
        {
            var stacks = GetStacks(input);
            var moves = GetMoves(input);
            MoveCratesCrateMover9001(stacks, moves);
            return GetTopCrates(stacks);
        }

        private static string GetTopCrates(Stack<char>[] stacks)
        {
            return String.Concat(stacks.Select(s => s.Peek()));
        }

        private static void MoveCratesCrateMover9000(Stack<char>[] stacks, List<Move> moves)
        {
            foreach (var move in moves)
            {
                for (int i = 0; i < move.count; i++)
                {
                    var pop = stacks[move.from - 1].Pop();
                    stacks[move.to-1].Push(pop);
                }
            }
        }

        private static void MoveCratesCrateMover9001(Stack<char>[] stacks, List<Move> moves)
        {
            foreach (var move in moves)
            {
                var temp = new Stack<char>();
                for (int i = 0; i < move.count; i++)
                {
                    temp.Push(stacks[move.from - 1].Pop());
                }

                while (temp.Count > 0)
                {
                    stacks[move.to - 1].Push(temp.Pop());
                }
            }
        }



        private static Stack<char>[] GetStacks(List<string> input)
        {
            var stackCounts = (input.First().Length + 1) / 4;
            var stacksArrayWrongOrder = new Stack<char>[stackCounts];
            for (int i = 0; i < stackCounts; i++)
            {
                stacksArrayWrongOrder[i] = new Stack<char>();
            }

            foreach (var row in input)
            {
                if (char.IsDigit(row[1])) //End at column/stack definition "numbers"
                    break;

                int stackIndex = 0;
                for (int i = 1; i < row.Length; i += 4)
                {
                    if (row[i] != ' ')
                    {
                        stacksArrayWrongOrder[stackIndex].Push(row[i]);
                    }
                    stackIndex++;
                }
            }

            //Reverce order due to reading from top to bottom from input.
            var stacksArray = new Stack<char>[stackCounts];
            for (int i = 0; i < stackCounts; i++)
            {
                stacksArray[i] = new Stack<char>();
                while (stacksArrayWrongOrder[i].Count > 0)
                {
                    stacksArray[i].Push(stacksArrayWrongOrder[i].Pop());
                }
            }

            return stacksArray;
        }        

        private static List<Move> GetMoves(List<string> input)
        {
            var moves = new List<Move>();
            foreach (var row in input)
            {
                var match = moveRegex.Match(row);
                if (match.Success == false)
                    continue;

                moves.Add(new Move(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value)));
            }

            return moves;
        }


        private record Move(int count, int from, int to);

    }
}
