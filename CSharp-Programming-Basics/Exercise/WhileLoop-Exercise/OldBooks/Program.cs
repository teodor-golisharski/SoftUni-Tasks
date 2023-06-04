using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string books = Console.ReadLine();
            int counter = 0;
            bool status = false;
            while (books != "No More Books")
            {
                if(books == s)
                {
                    status = true;
                    break;
                }
                counter++;
                books = Console.ReadLine(); 
            }
            if (status == true)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
        }
    }
}
