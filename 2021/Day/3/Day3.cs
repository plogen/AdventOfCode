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
            int gammaRate = 0;
            int epsilonRate = 0;

            var list = GetBitArrays(input);
            var mostCommon = GetMostCommonBit(list);
            Reverse(mostCommon);
            gammaRate = GetIntFromBitArray(mostCommon);
            mostCommon.Not();
            epsilonRate = GetIntFromBitArray(mostCommon);

            return gammaRate * epsilonRate;
        }

        public static int Part2(List<string> input)
        {
            int oxygenGeneratorRating = 0;
            int CO2scrubberRating = 0;
            var list = GetBitArrays(input);
            var mostCommon = GetMostCommonBit(list);

            for (int i = 0; i < mostCommon.Count; i++)
            {
                mostCommon = GetMostCommonBit(list);
                RemoveUnwantedInputs(list, !mostCommon[i], i);

                if (list.Count == 1)
                    break;
            }
            var lastRemainingOxygenInput = list.First();
            Reverse(lastRemainingOxygenInput);
            oxygenGeneratorRating = GetIntFromBitArray(lastRemainingOxygenInput);




            list = GetBitArrays(input);
            mostCommon = GetMostCommonBit(list);

            for (int i = 0; i < mostCommon.Count; i++)
            {
                mostCommon = GetMostCommonBit(list);
                RemoveUnwantedInputs(list, mostCommon[i], i);

                if (list.Count == 1)
                    break;
            }
            var lastRemainingCO2scrubberRatingInput = list.First();
            Reverse(lastRemainingCO2scrubberRatingInput);
            CO2scrubberRating = GetIntFromBitArray(lastRemainingCO2scrubberRatingInput);


            return oxygenGeneratorRating * CO2scrubberRating;
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
            var list = new int[input.First().Length];
            for (int i = 0; i < input.Count; i++)
            {
                for (int b = 0; b < input[i].Length; b++)
                {
                    if (input[i][b] == true)
                        list[b]++;
                }
            }

            BitArray output = new(input.First().Length);
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] >= ((float)input.Count / 2))
                    output[i] = true;
                else
                    output[i] = false;
            }
            
            return output;
        }

        public static int GetIntFromBitArray(BitArray input)
        {
            int value = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i])
                    value += Convert.ToInt16(Math.Pow(2, i));
            }
            return value;
        }

        public static void RemoveUnwantedInputs(List<BitArray> input, bool removeValue, int index)
        {
            input.RemoveAll(i => i[index] == removeValue);
        }




        public static void Reverse(BitArray array)
        {
            int length = array.Length;
            int mid = (length / 2);

            for (int i = 0; i < mid; i++)
            {
                bool bit = array[i];
                array[i] = array[length - i - 1];
                array[length - i - 1] = bit;
            }
        }



    }
}
