using System;
using System.Collections.Generic;

namespace _01_SortingAlgorithms
{
    public interface ISorter<T> where T : IComparable<T>
    {
        void Sort(IList<T> collection);
    }
}
