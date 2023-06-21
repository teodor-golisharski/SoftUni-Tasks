using System;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int filedSize = int.Parse(Console.ReadLine());
            int[] ladyBugsField = new int[filedSize];
            string[] occupiedIndex = Console.ReadLine().Split();
            for (int i = 0; i < occupiedIndex.Length; i++)
            {
                int curIndex = int.Parse(occupiedIndex[i]);
                if (curIndex >= 0 && curIndex < filedSize)
                {
                    ladyBugsField[curIndex] = 1;
                }
            }
            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "end")
            {
                bool check = true;
                int curIndex = int.Parse(commands[0]);
                while (curIndex >= 0 && curIndex < filedSize && ladyBugsField[curIndex] != 0)
                {
                    if (check)
                    {
                        ladyBugsField[curIndex] = 0;
                        check = false;
                    }
                    string direction = commands[1];
                    int flightLenght = int.Parse(commands[2]);
                    if (direction == "left")
                    {
                        curIndex -= flightLenght;
                        if (curIndex >= 0 && curIndex < filedSize)
                        {
                            if (ladyBugsField[curIndex] == 0)
                            {
                                ladyBugsField[curIndex] = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        curIndex += flightLenght;
                        if (curIndex >= 0 && curIndex < filedSize)
                        {
                            if (ladyBugsField[curIndex] == 0)
                            {
                                ladyBugsField[curIndex] = 1;
                                break;
                            }
                        }
                    }
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", ladyBugsField));
        }
    }
}
