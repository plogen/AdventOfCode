using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Helper
    {
        public static bool IsPositive(this int number)
        {
            return number > 0;
        }

        public static bool IsNegative(this int number)
        {
            return number < 0;
        }

        public static bool IsZero(this int number)
        {
            return number == 0;
        }

        public static readonly Dictionary<string, Func<int, int, int>> Operators = new ()
        {
            {"+", (x,y) => x+y},
            {"-", (x,y) => x-y},
            {"*", (x,y) => x*y},
            {"/", (x,y) => x/y}
        };



        public static string GetSolutionDir()
        {
            string solutionDir = string.Empty;
            #if DEBUG
                solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            #else
                solutionDir = Environment.CurrentDirectory;
            #endif
            return solutionDir;
        }

    }
}
