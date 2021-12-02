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
                Row = GetRow(input)
            };  

            return boardingPass;
        }

        public static int GetRow(string input)
        {
            int min = 0;
            int max = 127;
            for (int i = 0; i < 6; i++)
            {
                if (input[i] == 'F')
                    max = (max - min) / 2;
                if (input[i] == 'B')
                    min = ((max - min) / 2) + 1;
            }
            return min;
        }
    }

    public class BoardingPass
    {
        public string Input { get; set; }
        public int SeatID { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
