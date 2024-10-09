using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public int Count 
        {
            get { return this.list.Count; } 
        }
        public void Add(T element)
        {
            this.list.Insert(0, element);
        }
        public T Remove()
        {
            T element = this.list[0];
            list.Remove(element);
            return element;
        }
    }
}
