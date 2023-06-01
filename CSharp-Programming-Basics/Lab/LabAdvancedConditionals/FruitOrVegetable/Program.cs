using System;

namespace FruitOrVegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string status="";
            switch(product)
            {
                case "banana": 
                case "apple": 
                case "kiwi": 
                case "cherry": 
                case "lemon": 
                case "grapes": status = "fruit";break;

                case "tomato":
                case "cucumber":
                case "pepper":
                case "carrot": status = "vegetable";break;

                default: status = "unknown";break;
            }
            Console.WriteLine(status);
        }
    }
}
