using System;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\${6,}|\@{6,}|#{6,}|\^{6,}";
            Regex regex = new Regex(pattern);
            string[] lotteryTickets = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string ticket in lotteryTickets)
            {
                if (ticket.Length == 20)
                {
                    Match matchFirst = regex.Match(ticket.Substring(0, 10));
                    Match matchSecond = regex.Match(ticket.Substring(10));
                    int min = Math.Min(matchFirst.Length, matchSecond.Length);
                    if (matchFirst.Success && matchSecond.Success)
                    {
                        string winFirst = matchFirst.Value.Substring(0, min);
                        string winSecond = matchSecond.Value.Substring(0, min);
                        if (winFirst.Equals(winSecond))
                        {
                            if (winFirst.Length >= 6 && winFirst.Length < 10)
                            {
                                Console.WriteLine($"ticket \"{ticket}\" - {winFirst.Length}{matchFirst.Value.Substring(0, 1)}");
                            }
                            else if (winFirst.Length == 10)
                            {
                                Console.WriteLine($"ticket \"{ticket}\" - {winFirst.Length}{matchFirst.Value.Substring(0, 1)} Jackpot!");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - no match");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}
