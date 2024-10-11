using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Food;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Animal> animals = new HashSet<Animal>();

            string animalInput = Console.ReadLine();

            while (animalInput != "End")
            {
                string[] animalArgs = animalInput.Split(' ');

                string type = animalArgs[0];
                string name = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                string fourthArg = animalArgs[3];

                Animal animal = null;

                switch (type)
                {
                    case "Owl": animal = new Owl(name, weight, double.Parse(fourthArg)); break;
                    case "Hen": animal = new Hen(name, weight, double.Parse(fourthArg)); break;
                    case "Mouse": animal = animal = new Mouse(name, weight, fourthArg); break;
                    case "Dog": animal = new Dog(name, weight, fourthArg); break;
                    case "Cat": animal = new Cat(name, weight, fourthArg, animalArgs[4]); break;
                    case "Tiger": animal = new Tiger(name, weight, fourthArg, animalArgs[4]); break;
                }
                animals.Add(animal);

                string[] foodInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string foodType = foodInput[0];

                int quantity = int.Parse(foodInput[1]);

                WildFarm.Food.Food food = null;

                Console.WriteLine(animal.ProduceSound());
                try
                {
                    switch (foodType)
                    {
                        case "Vegetable": food = new Vegetable(quantity); break;
                        case "Fruit": food = new Fruit(quantity); break;
                        case "Meat": food = new Meat(quantity); break;
                        case "Seeds": food = new Seeds(quantity); break;
                    }
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                animalInput = Console.ReadLine();
            }
            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
