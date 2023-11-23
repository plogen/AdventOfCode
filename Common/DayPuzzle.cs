using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public abstract class DayPuzzle
    {
        protected List<string> input;

        public DayPuzzle()
        {
        }


        public abstract object Part1(List<string> input);

        public abstract object Part2(List<string> input);
    }
}
