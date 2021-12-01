using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ReadInputFile
    {

        public static List<int> GetInput(int day, string fileName)
        {
            List<int> list = new List<int>();
            int line = 1;
            string lineData;
            try
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var path = Path.Combine(currentDirectory, "Day", day.ToString(), fileName);
                using (var sr = new StreamReader(path))
                {
                    while ((lineData = sr.ReadLine()) != null)
                    {
                        ushort value;
                        if (ushort.TryParse(lineData, out value))
                        {
                            list.Add(value);
                        }
                        else
                        {
                            throw new Exception("error in parsing");
                        }
                        line++;
                    }
                }
            }
            catch (IOException e)
            {
                throw new Exception("error in parsing");
            }

            return list;
        }

    }
}
