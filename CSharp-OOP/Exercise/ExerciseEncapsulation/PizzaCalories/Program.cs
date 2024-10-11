using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split()[1];

                string[] doughInput = Console.ReadLine().Split();
                string flourType = doughInput[1];
                string bakingTechnique = doughInput[2];
                double pizzaWeight = double.Parse(doughInput[3]);
                Dough dough = new Dough(flourType, bakingTechnique, pizzaWeight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string toppingsInfo = Console.ReadLine();
                while (toppingsInfo != "END")
                {
                    string[] tokens = toppingsInfo
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string type = tokens[1];
                    double weight = double.Parse(tokens[2]);
                    Topping topping = new Topping(type, weight);
                    pizza.AddTopping(topping);

                    toppingsInfo = Console.ReadLine();
                }

                Console.WriteLine($"{pizzaName} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
