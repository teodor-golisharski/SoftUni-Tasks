using System;

namespace SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            string[] input = Console.ReadLine().Split();

            foreach (var item in input)
            {
                bool flag = false;
                try
                {
                    flag = Validation(item);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if(flag)
                {
                    sum += int.Parse(item);
                }
                Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }

        static bool Validation(string element)
        {
            bool flag = false;
            
            long number;

            if(!long.TryParse(element, out number))
            {
                throw new FormatException($"The element '{element}' is in wrong format!");
            }
            try
            {
                number = Convert.ToInt32(number);
            }
            catch(OverflowException)
            {
                throw new OverflowException($"The element '{element}' is out of range!");
            }

            flag = true;
            
            return flag;
        }
    }
}
