using System;
using System.Text;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] tokens = command.Split();
                string mainCommand = tokens[0];
                switch (mainCommand)
                {
                    case "TakeOdd":
                        string replacement = string.Empty;
                        for (int i = 1; i < password.Length; i += 2)
                        {
                            replacement += password[i];
                        }
                        password = replacement;
                        Console.WriteLine(password);
                        break;

                    case "Cut":
                        int index = int.Parse(tokens[1]);
                        int length = int.Parse(tokens[2]);
                        string firstHalf = password.Substring(0, index);
                        string secondHalf = password.Substring(index + length);
                        password = firstHalf + secondHalf;
                        Console.WriteLine(password);
                        break;

                    case "Substitute":
                        string substring = tokens[1];
                        string substitute = tokens[2];
                        if(password.Contains(substring))
                        {
                            password = password.Replace(substring, substitute);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
