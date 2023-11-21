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
            string solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            var type = this.GetType().FullName.Split(".");
            var className = type[type.Length - 1].ToLower();

            var assemblyName = this.GetType().Namespace;
            var inputaddition = assemblyName.Substring(assemblyName.Length - 4);

            var dirPath = solutionDir + "\\" + assemblyName + "\\" + "input" + inputaddition;

            var file = Directory.GetFiles(dirPath)
                .Where(x => x.ToLower().Contains($"{className}"))
                .Single();

            //raw = File.ReadAllText(file);
        }


        public abstract object Part1(List<string> input);

        public abstract object Part2(List<string> input);
    }
}
