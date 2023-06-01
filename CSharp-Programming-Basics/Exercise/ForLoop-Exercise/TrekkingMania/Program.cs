using System;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double musala = 0;
            double montblanc = 0;
            double kilimanjaro = 0;
            double k2 = 0;
            double everest = 0;
            for (int i = 1; i <= n; i++)
            {
                int people = int.Parse(Console.ReadLine());
                if (people <= 5)
                {
                    musala += people;
                }
                else if (people >= 6 && people <= 12)
                {
                    montblanc += people;
                }
                else if (people >= 13 && people <= 25)
                {
                    kilimanjaro += people;
                }
                else if (people >= 26 && people <= 40)
                {
                    k2 += people;
                }
                else if (people >= 41)
                {
                    everest += people;
                }
            }
            double totalPeople = musala + montblanc + kilimanjaro + k2 + everest;
            Console.WriteLine($"{(musala/totalPeople*100):f2}%");
            Console.WriteLine($"{(montblanc/totalPeople*100):f2}%");
            Console.WriteLine($"{(kilimanjaro/totalPeople*100):f2}%");
            Console.WriteLine($"{(k2/totalPeople*100):f2}%");
            Console.WriteLine($"{(everest/totalPeople*100):f2}%");
        }
    }
}
