using System;
using System.Linq;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string[] command = Console.ReadLine().Split(">>>");
            while (command[0] != "Generate")
            {
                string mainCommand = command[0];
                switch (mainCommand)
                {
                    case "Contains":
                        string sub = command[1];
                        if (activationKey.Contains(sub))
                        {
                            Console.WriteLine($"{activationKey} contains {sub}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;

                    case "Flip":
                        string commandDetails = command[1];
                        int startIndex = int.Parse(command[2]);
                        int endIndex = int.Parse(command[3]);
                        string substring = activationKey.Substring(startIndex, endIndex - startIndex);
                        string res = string.Empty;
                        if (commandDetails == "Upper")
                        {
                            res = substring.ToUpper();
                        }
                        else if(commandDetails == "Lower")
                        {
                            res = substring.ToLower();
                        }
                        activationKey = activationKey.Replace(substring, res);
                        Console.WriteLine(activationKey);
                        break;

                    case "Slice":
                        int sIndex = int.Parse(command[1]);
                        int eIndex = int.Parse(command[2]);
                        activationKey = activationKey.Remove(sIndex, eIndex - sIndex);
                        Console.WriteLine(activationKey);
                        break;
                }
                command = Console.ReadLine().Split(">>>");
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
