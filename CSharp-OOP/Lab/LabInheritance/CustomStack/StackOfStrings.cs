using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0; 
        }
        public void AddRange(IEnumerable<string> range)
        {
            foreach (string item in range)
            {
                this.Push(item);
            }
        }
    }
}
