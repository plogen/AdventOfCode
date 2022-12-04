using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class IEnumerableExtentions
    {
        //public static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize = 30)
        //{
        //    for (int i = 0; i < locations.Count; i += nSize)
        //    {
        //        yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
        //    }
        //}


        public static List<List<T>> MakeChunks<T>(this List<T> values, int chunkSize)
        {
            return values.Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

    }



}
