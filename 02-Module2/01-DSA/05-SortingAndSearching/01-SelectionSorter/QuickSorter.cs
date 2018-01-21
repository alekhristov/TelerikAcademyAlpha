using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_SortingAlgorithms
{
    class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public IEnumerable<int> Sort(IList<int> collection)
        {
            if (collection.Count < 2)
            {
                return collection.ToList();
            }

            int pivotIndex = collection.Count / 2;

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0; i < collection.Count; i++)
            {
                if (i == pivotIndex)
                {
                    continue;
                }
                else if (collection[i] < collection[pivotIndex])
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            var result = new List<int>();
            result.AddRange(Sort(left));
            result.Add(collection[pivotIndex]);
            result.AddRange(Sort(right));

            return result;
        }
    }
}
