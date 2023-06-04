using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double standard = 0;
            double student = 0;
            double kid = 0;
            int totalSeats = 0;

            string movie;
            while ((movie = Console.ReadLine()) != "Finish")
            {
                int seatsMovie = int.Parse(Console.ReadLine());
                int takenSeats = 0;
                string type;
                while (takenSeats < seatsMovie && (type = Console.ReadLine()) != "End")
                {
                    switch (type)
                    {
                        case "kid": kid++; break;
                        case "student": student++; break;
                        case "standard": standard++; break;
                    }
                    takenSeats++;
                }
                double s = (double)takenSeats / (double)seatsMovie * 100;
                Console.WriteLine($"{movie} - {s:f2}% full.");
                totalSeats += takenSeats;

            }
            Console.WriteLine("Total tickets: " + totalSeats);
            Console.WriteLine($"{student / totalSeats * 100:f2}% student tickets.");
            Console.WriteLine($"{standard / totalSeats * 100:f2}% standard tickets.");
            Console.WriteLine($"{kid / totalSeats * 100:f2}% kids tickets.");
        }
    }
}
