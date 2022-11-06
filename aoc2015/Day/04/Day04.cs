using Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    public static class Day04
    {

        public static int FindMinMD5(string input, string prefix)
        {
            var queue = new ConcurrentQueue<int>();

            Parallel.ForEach(
                Enumerable.Range(0, int.MaxValue),
                () => MD5.Create(),
                (i, state, md5) => {
                    var hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(input + i));
                    var hash = string.Join("", hashBytes.Select(b => b.ToString("x2")));

                    if (hash.StartsWith(prefix))
                    {
                        queue.Enqueue(i);
                        state.Stop();
                    }
                    return md5;
                },
                (_) => { } //Finally action nott needed because queue is updated in parallel
            );

            return queue.Min();

        }


        public static int Part1(string input)
        {
            return FindMinMD5(input, "00000");
        }

        public static int Part2(string input)
        {
            return FindMinMD5(input, "000000");
        }

    }
}
