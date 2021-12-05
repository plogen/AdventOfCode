using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    public static class Day3
    {
        public static int Part1(List<string> input)
        {
            var list = GetBitArrays(input);
            var mostCommon = GetMostCommonBit(list);
            var x = GetIntFromBitArray(mostCommon);

            int gammaRate = 0;
            int epsilonRate = 0;
            return gammaRate * epsilonRate;
        }

        public static int Part2(List<string> input)
        {
            return 0;
        }

        public static List<BitArray> GetBitArrays(List<string> input)
        {
            List<BitArray> bitArrays = new List<BitArray>();
            foreach (string bits in input)
            {
                BitArray output = new(bits.Length);
                //bits.Select((b, i) => b == '0' ? output[i] = false : output[i] = true);
                for (int i = 0; i < bits.Length; i++)
                {
                    if (bits[i] == '0')
                        output[i] = false;
                    else
                        output[i] = true;
                }
                bitArrays.Add(output);
            }
            return bitArrays;
        }

        public static BitArray GetMostCommonBit(List<BitArray> input)
        {
            var list = new int[5];
            for (int i = 0; i < input.Count; i++)
            {
                for (int b = 0; b < input[i].Length; b++)
                {
                    if (input[i][b] == true)
                        list[b]++;
                }
            }

            BitArray output = new(5);
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] > (input.Count / 2))
                    output[i] = true;
                else
                    output[i] = false;
            }
            
            return output;
        }

        public static int GetIntFromBitArray(BitArray input)
        {
            //int[] array = new int[1];
            //input.CopyTo(array, 0);
            //return array[0];

            int value = 0;
            for (int i = input.Count-1; i >= 0; i--)
            {
                if (input[i])
                    value += Convert.ToInt16(Math.Pow(2, i));
            }
            return value;


            //var result = new int[1];
            //input.CopyTo(result, 0);
            //return result[0];


        }



    }
}
