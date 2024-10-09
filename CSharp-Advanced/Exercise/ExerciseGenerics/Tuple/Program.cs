using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] drinkInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] numInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string city = string.Empty;
            if(personInfo.Length == 4)
            {
                city = personInfo[3];
            }
            else if(personInfo.Length == 5)
            {
                city = personInfo[3] + " " + personInfo[4];
            }


            Threeuple<string, string, string> tuple1 = new Threeuple<string, string, string>
            {
                Item1 = personInfo[0] + " " + personInfo[1],
                Item2 = personInfo[2],
                Item3 = city
            };

            Threeuple<string, string, bool> tuple2 = new Threeuple<string, string, bool>
            {
                Item1 = drinkInfo[0],
                Item2 = drinkInfo[1],
                Item3 = (drinkInfo[2] == "drunk")
            };

            Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>
            {
                Item1 = numInfo[0],
                Item2 = double.Parse($"{numInfo[1]}"),
                Item3 = numInfo[2]
            };

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
