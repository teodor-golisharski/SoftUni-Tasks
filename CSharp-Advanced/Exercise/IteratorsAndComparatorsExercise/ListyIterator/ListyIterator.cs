using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index = 0;

        private List<T> items;

        public ListyIterator(List<T> items)
        {
            this.items = items;
        }

        public bool Move()
        {
            if (index + 1 < items.Count)
            {
                index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            return index < items.Count - 1;
        }
        public void Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(items[index]);
        }
        public void PrintAll()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            foreach (var item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return items[index];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
