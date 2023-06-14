using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string password = "";
            char c;
            int counter = 0;
            for (int i = 1; i <= s.Length; i++)
            {
                c = s[s.Length - i];
                password += c;
            }
            string text = Console.ReadLine();
            while (text != password)
            {
                counter++;
                if(counter>3)
                {
                    Console.WriteLine($"User {s} blocked!");return;
                }
                Console.WriteLine("Incorrect password. Try again.");
                text = Console.ReadLine();
            }
            if(text == password)
            {
                Console.WriteLine($"User {s} logged in.");
            }
            
        }
    }
}
