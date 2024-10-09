using System;
using System.Collections.Generic;

namespace Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> carsToPass = new Queue<string>();
            Queue<string> passedCars = new Queue<string>();
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "END")
            {
                if (input != "green")
                {
                    carsToPass.Enqueue(input);
                }
                else
                {
                    int green = greenLight;
                    int free = freeWindow;
                    int counter = carsToPass.Count;
                    for (int i = 0; i < counter; i++)
                    {
                        if (carsToPass.Count != 0 && green >= carsToPass.Peek().Length)
                        {
                            green -= carsToPass.Peek().Length;
                            passedCars.Enqueue(carsToPass.Dequeue());
                        }
                        else if (carsToPass.Count != 0 && green < carsToPass.Peek().Length)
                        {
                            int timeLeft = green + free;
                            if(green <= 0)
                            {
                                continue;
                            }
                            else if(timeLeft>0 && timeLeft>=carsToPass.Peek().Length)
                            {
                                string car = carsToPass.Peek();
                                timeLeft -= car.Length;
                                passedCars.Enqueue(carsToPass.Dequeue());
                                green = 0;
                                free = 0;
                            }
                            else if(timeLeft >0 && timeLeft < carsToPass.Peek().Length)
                            {
                                string car = carsToPass.Peek();
                                Console.WriteLine("A crash happened!");
                                int hit = timeLeft;
                                Console.WriteLine($"{car} was hit at {car[hit]}.");
                                return;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars.Count} total cars passed the crossroads.");
        }
    }
}
