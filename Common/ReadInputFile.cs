using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ReadInputFile
    {

        public static List<string> GetInput(int day, string fileName)
        {
            List<string> list = new();
            string? lineData;
            try
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var path = Path.Combine(currentDirectory, "Day", day.ToString(), fileName);
                using (var sr = new StreamReader(path))
                {
                    while ((lineData = sr.ReadLine()) != null)
                    {
                        list.Add(lineData);
                    }
                }
            }
            catch (IOException)
            {
                throw new Exception("error in parsing");
            }

            return list;
        }

        public static List<string> GetInputDayPadding(int day, string fileName)
        {
            List<string> list = new();
            string? lineData;
            try
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var path = Path.Combine(currentDirectory, "Day", day.ToString().PadLeft(2, '0'), fileName);
                using (var sr = new StreamReader(path))
                {
                    while ((lineData = sr.ReadLine()) != null)
                    {
                        list.Add(lineData);
                    }
                }
            }
            catch (IOException)
            {
                throw new Exception("error in parsing");
            }

            return list;
        }


        public static int[][] GetInputAsMultiArrayInt(List<string> input)
        {
            int[][] output = null!;
            output = new int[input.Count][];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = input[i].Trim().Select(x => x - '0').ToArray();
            }
            return output;
        }


    }
}
