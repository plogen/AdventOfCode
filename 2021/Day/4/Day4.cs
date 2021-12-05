using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2021
{
    public static class Day4
    {
        public static int Part1(List<string> input)
        {
            var drawnNumbers = GetDrawnNumbers(input);
            List<Board> boards = GetBoards(input);

            foreach (var number in drawnNumbers)
            {
                foreach (var board in boards.Where(b => b.Positions.Any(p => p.Value == number)))
                {
                    board.Positions.FirstOrDefault(p => p.Value == number).Drawn = true;

                }

                var winners = GetWinners(boards);

                if (winners.Count > 0)
                {
                    var firstWinner = winners.First();
                    var allNotDrawn = firstWinner.Positions.Where(p => p.Drawn == false).ToList().Sum(p => p.Value);
                    return allNotDrawn * number;

                    //var firstWinner = winners.First();
                    //var w = firstWinner.Winning.FirstOrDefault();
                    //var num = int.Parse(w.Substring(1));
                    //if (w[0] == 'x')
                    //{
                    //    var winningRow = firstWinner.Positions.Where(p => p.X == num).ToList();

                    //}
                }
            }
            return 0;
        }

        public static int Part2(List<string> input)
        {
            var drawnNumbers = GetDrawnNumbers(input);
            List<Board> boards = GetBoards(input);
            Board lastWinner = null;
            foreach (var number in drawnNumbers)
            {
                foreach (var board in boards.Where(b => b.Positions.Any(p => p.Value == number)))
                {
                    board.Positions.FirstOrDefault(p => p.Value == number).Drawn = true;

                }
                var winners = GetWinners(boards);
                if (lastWinner == null && winners.Count == (boards.Count - 1))
                {
                    lastWinner = boards.FirstOrDefault(b => b.Winning.Count == 0);
                }
                else if (winners.Count == (boards.Count))
                {
                    var allNotDrawn = lastWinner.Positions.Where(p => p.Drawn == false).ToList().Sum(p => p.Value);
                    return allNotDrawn * number;
                }


            }
            return 0;
        }





        private static int[] GetDrawnNumbers(List<string> input)
        {
            return input.First().Split(',').Select(int.Parse).ToArray();
        }

        private static List<Board> GetBoards(List<string> input)
        {
            List<Board> boards = new();

            Board board = new Board();
            int boardRow = 0;
            for (int i = 2; i < input.Count; i++)
            {
                if (input[i].Length <= 1)
                {
                    boardRow = 0;
                    boards.Add(board);
                    board = new Board();
                    continue;
                }

                var row = input[i].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                for (int x = 0; x < row.Length; x++)
                {
                    board.Positions.Add(new Pos() { X = x, Y = boardRow, Value = int.Parse(row[x]) });
                }

                boardRow++;

                if (i == (input.Count - 1))
                    boards.Add(board);

            }

            return boards;
        }


        public static List<Board> GetWinners(List<Board> input)
        {
            List<Board> boards = new();
            foreach (var board in input)
            {
                for (int x = 0; x < 5; x++)
                {
                    var xResult = board.Positions.Where(p => p.X == x).All(p => p.Drawn);
                    var yResult = board.Positions.Where(p => p.Y == x).All(p => p.Drawn);

                    if (xResult)
                        board.Winning.Add("x" + x);
                    if (yResult)
                        board.Winning.Add("y" + x);

                    if (xResult || yResult)
                    {
                        boards.Add(board);
                        break;
                    }
                }


                //var xRowWinner = board.Positions.GroupBy(x => x.X)
                //                        .SelectMany(t => t)
                //                        .ToList()
                //                        .All(p => p.Drawn);

                //var yRowWinner = board.Positions.GroupBy(p => p.Y)
                //                        .SelectMany(t => t)
                //                        .ToList()
                //                        .All(p => p.Drawn);

                //if (xRowWinner || yRowWinner)
                //    boards.Add(board);



            }
            return boards;
        }


        public class Board
        {
            public List<string> Winning { get; set; } = new List<string>();
            public List<Pos> Positions { get; set; } = new List<Pos>();
        }

        public class Pos
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Value { get; set; }
            public bool Drawn { get; set; }
        }

    }
}
