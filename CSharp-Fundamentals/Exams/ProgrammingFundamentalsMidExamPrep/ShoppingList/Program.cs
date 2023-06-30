using System;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int current = 0;
            int onLift = 0;
            bool flag = false;
            for (int i = 0; i < arr.Length; i++)
            {
                while (arr[i] < 4)
                {
                    arr[i]++;
                    current++;
                    if (onLift + current == n)
                    {
                        flag = true;
                        break;
                    }
                }
                onLift += current;
                if (flag)
                {
                    break;
                }
                current = 0;
            }
            if (n > onLift)
            {
                Console.WriteLine($"There isn't enough space! {n - onLift} people in a queue!");
                Console.WriteLine(string.Join(" ", arr));
            }
            else if (n < arr.Length*4&&arr.Any(w=>w<4))
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", arr));
            }
            else if (arr.All(w=>w==4)&& flag)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
