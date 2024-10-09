using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BoxOfString
{
    public class Box<T> where T : IComparable
    {
        public Box()
        {
            data = new List<T>();
        }

        private List<T> data;

        public List<T> Data
        {
            get { return data; }
            set { data = value; }
        }
        private bool IndexCheker(int index)
        {
            return index >= 0 && index < data.Count;
        }
        public void Swap(int index1, int index2)
        {
            if (IndexCheker(index1) && IndexCheker(index2))
            {
                T temp = data[index1];
                data[index1] = data[index2];
                data[index2] = temp;
            }
        }
        public int Count(T element)
        {
            int count = 0;
            foreach (var item in Data)
            {
                if(item.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in data)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
