using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Algorithms
    {
        //https://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }


        public static IEnumerable<int[]> GetPermutationsByRemovingEachposition(int[] list)
        {
            List<int[]> permutations = new List<int[]>();
            for (int i = 0; i <= list.Length; i++)
            {
                IEnumerable<int> before = list.Take(i-1);
                IEnumerable<int> after = list.Skip(i);
                permutations.Add(Enumerable.Concat(before, after).ToArray());
            }
            return permutations;
        }





        //https://stackoverflow.com/questions/13569810/least-common-multiple
        //https://en.wikipedia.org/wiki/Euclidean_algorithm
        static long GreatestCommonFactor(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        static long LeastCommonMultiple(long a, long b)
        {
            return (a / GreatestCommonFactor(a, b)) * b;
        }
        public static long AggregatedLeastCommonMultiple(long[] numbers)
        {
            return numbers.Aggregate((S, val) => LeastCommonMultiple(S, val));
        }



    }
}
