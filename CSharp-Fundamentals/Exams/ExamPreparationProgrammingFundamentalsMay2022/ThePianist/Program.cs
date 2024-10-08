using System;
using System.Collections.Generic;

namespace ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('|');
                string piece = input[0];
                string composer = input[1];
                string key = input[2];
                List<string> temp = new List<string>();
                temp.Add(composer);
                temp.Add(key);
                pieces.Add(piece, temp);
            }
            string[] commands = Console.ReadLine().Split('|');
            while (commands[0] != "Stop")
            {
                string mainCommand = commands[0];
                switch (mainCommand)
                {
                    case "Add":
                        string piece = commands[1];
                        string composer = commands[2];
                        string key = commands[3];
                        if (pieces.ContainsKey(piece))
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                        }
                        else
                        {
                            List<string> temp = new List<string>();
                            temp.Add(composer);
                            temp.Add(key);
                            pieces.Add(piece, temp);
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        }
                        break;

                    case "Remove":
                        string currentPiece = commands[1];
                        if (pieces.ContainsKey(currentPiece))
                        {
                            pieces.Remove(currentPiece);
                            Console.WriteLine($"Successfully removed {currentPiece}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {currentPiece} does not exist in the collection.");
                        }
                        break;

                    case "ChangeKey":
                        string currPiece = commands[1];
                        string newKey = commands[2];
                        bool flag = false;
                        foreach (var item in pieces)
                        {
                            if (item.Key == currPiece)
                            {
                                item.Value[1] = newKey;
                                Console.WriteLine($"Changed the key of {currPiece} to {newKey}!");
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            Console.WriteLine($"Invalid operation! {currPiece} does not exist in the collection.");
                        }
                        break;
                }
                commands = Console.ReadLine().Split('|');
            }
            foreach (var item in pieces)
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }
        }
    }
}
