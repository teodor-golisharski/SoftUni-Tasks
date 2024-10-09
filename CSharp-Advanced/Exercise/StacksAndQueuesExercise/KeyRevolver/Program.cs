using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            int intelligenceValue = int.Parse(Console.ReadLine());
            int reloader = gunBarrelSize;
            int wallet = 0;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                int currentBullet = bullets.Pop();
                reloader--;
                wallet -= bulletPrice;
                
                int currentLock = locks.Peek();
                if(currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (reloader == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    if (bullets.Count > gunBarrelSize)
                    {
                        reloader = gunBarrelSize;
                    }
                    else
                    {
                        reloader = bullets.Count;
                    }
                }
            }
            if(locks.Count == 0)
            {
                wallet += intelligenceValue;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${wallet}");
            }
            else if(bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
