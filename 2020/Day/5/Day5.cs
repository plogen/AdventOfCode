using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020.Day._5
{
    public static class Day5
    {
        public static int Part1(string[] input)
        {
            var boardingPass = GetBoardingPass(input.First());
            return boardingPass.SeatID;
        }

        public static BoardingPass GetBoardingPass(string input)
        {
            BoardingPass boardingPass = new() { 
                Input = input,
                Row = GetRow(input),
                Col = GetCol(input)
            };
            boardingPass.SeatID = GetSeatID(boardingPass);

            return boardingPass;
        }

        public static int GetRow(string input)
        {
            int min = 0;
            int max = 127;
            for (int i = 0; i < 6; i++)
            {
                if (input[i] == 'F')
                    max = min + ((max - min) / 2);
                if (input[i] == 'B')
                    min = min + ((max - min) / 2) + 1;
            }
            return min;
        }

        public static int GetCol(string input)
        {
            int min = 0;
            int max = 7;
            for (int i = 7; i < input.Length; i++)
            {
                if (input[i] == 'L')
                    max = min + ((max - min) / 2);
                if (input[i] == 'R')
                    min = min + ((max - min) / 2) + 1;
            }
            return min;
        }

        public static int GetSeatID(BoardingPass boardingPass)
        {
            return (boardingPass.Row * 8 + boardingPass.Col);
        }

    }

    public record struct BoardingPass
    {
        public string Input { get; set; }
        public int SeatID { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
