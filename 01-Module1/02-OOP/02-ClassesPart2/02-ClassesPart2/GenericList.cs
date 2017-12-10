using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_ClassesPart2
{
    class GenericList<T>
    {
        private List<T> genericList;
        private int capacity = 4;

        internal T this[int index]
        {
            get
            {
                Guard.WhenArgument(index, $"Index [{index}] is invalid!").IsLessThan(0).IsGreaterThan(genericList.Count - 1).Throw();
                return this.genericList[index];
            }
            set
            {
                Guard.WhenArgument(index, $"Index [{index}] is invalid!").IsLessThan(0).IsGreaterThan(genericList.Count - 1).Throw();
                this.genericList[index] = value;
            }
        }

        internal GenericList()
        {
            this.genericList = new List<T>(capacity);
        }

        internal void Add(T element)
        {
            this.genericList.Add(element);

            if (genericList.Count == capacity)
            {
                capacity *= 2;
                var genericListClone = genericList;
                genericList = new List<T>(capacity);
                genericList.AddRange(genericListClone);
            }
        }

        internal T AccessElementAt(int index)
        {
            Guard.WhenArgument(index, $"Index [{index}] is invalid!").IsLessThan(0).IsGreaterThan(genericList.Count - 1).Throw();
            return this.genericList[index];
        }

        internal void RemoveElementAt(int index)
        {
            Guard.WhenArgument(index, $"Index [{index}] is invalid!").IsLessThan(0).IsGreaterThan(genericList.Count - 1).Throw();
            genericList.RemoveAt(index);
        }

        internal void InsertElementAt(int index, T element)
        {
            Guard.WhenArgument(index, $"Index [{index}] is invalid!").IsLessThan(0).IsGreaterThan(genericList.Count - 1).Throw();
            genericList.Insert(index, element);
        }

        internal void ClearList()
        {
            genericList.Clear();
        }

        internal int FindElementIndex(T element)
        {
            return genericList.IndexOf(element);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < genericList.Count; i++)
            {
                sb.AppendLine($"genericList[{i}] = {genericList[i]}");
            }
            return sb.ToString();
        }

        public T Min<T>(T first, T second)
            where T : IComparable<T>
        {
            if (first.CompareTo(second) <= 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
        public T Max<T>(T first, T second)
           where T : IComparable<T>
        {
            if (first.CompareTo(second) > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

    }
}
