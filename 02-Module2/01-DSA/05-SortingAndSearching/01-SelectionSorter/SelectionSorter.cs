using System;
using System.Collections.Generic;

namespace _01_SortingAlgorithms
{
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (var i = 0; i < collection.Count - 1; i++)
            {
                var minIndex = i;

                for (var j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (!minIndex.Equals(i))
                {
                    var temp = collection[minIndex];
                    collection[minIndex] = collection[i];
                    collection[i] = temp;
                }
            }
        }
    }
}
