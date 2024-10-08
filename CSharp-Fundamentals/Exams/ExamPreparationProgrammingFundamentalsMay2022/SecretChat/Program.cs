using System;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Reveal")
                {
                    break;
                }
                string[] tokens = command.Split(":|:");
                string action = tokens[0];
                switch (action)
                {
                    case "InsertSpace":
                        int index = int.Parse(tokens[1]);
                        message = message.Insert(index, " ");
                        break;

                    case "Reverse":
                        string sub = tokens[1];
                        if (message.Contains(sub))
                        {
                            string reversed = Reverse(sub);
                            int subIndex = message.IndexOf(sub);
                            message = message.Remove(subIndex, sub.Length);
                            message += reversed;
                        }
                        else
                        {
                            Console.WriteLine("error");
                                continue;
                        }
                        break;

                    case "ChangeAll":
                        string substring = tokens[1];
                        string replacement = tokens[2];
                        message = message.Replace(substring, replacement);
                        break;
                }
                Console.WriteLine(message);
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
        static string Reverse(string sub)
        {
            string reversed = string.Empty;
            for (int i = sub.Length - 1; i >= 0; i--)
            {
                reversed += sub[i];
            }
            return reversed;
        }
    }
}
