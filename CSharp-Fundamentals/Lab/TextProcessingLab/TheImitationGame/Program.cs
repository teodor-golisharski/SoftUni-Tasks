using System;

namespace TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            string[] command = Console.ReadLine().Split('|');
            while (command[0] != "Decode")
            {
                string commandType = command[0];
                switch (commandType)
                {
                    case "Move":
                        int n = int.Parse(command[1]);
                        string move = string.Empty;
                        while (n != 0)
                        {
                            move += encryptedMessage[0];
                            encryptedMessage = encryptedMessage.Remove(0, 1);
                            n--;
                        }
                        encryptedMessage += move;
                        break;

                    case "Insert":
                        int index = int.Parse(command[1]);
                        string value = command[2];
                        encryptedMessage = encryptedMessage.Insert(index, value);
                        break;

                    case "ChangeAll":
                        string sub = command[1];
                        string replacement = command[2];
                        while (encryptedMessage.Contains(sub))
                        {
                            encryptedMessage = encryptedMessage.Replace(sub, replacement);
                        }
                        break;
                }
                command = Console.ReadLine().Split('|');
            }
            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
