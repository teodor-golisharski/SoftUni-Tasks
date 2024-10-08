using System;
using System.Diagnostics;
using System.Text;

namespace StringBuilderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //string text = "";
            //for (int i = 0; i < 100000; i++)
            //    text += i;
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < 100000; i++)
                text.Append(i);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
