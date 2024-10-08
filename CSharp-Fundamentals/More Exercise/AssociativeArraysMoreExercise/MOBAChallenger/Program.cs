using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> playerStats = new Dictionary<string, Dictionary<string, int>>();
            while (input != "Season end")
            {
                if (input.Contains("->"))
                {
                    string[] data = input.Split(" -> ");
                    string player = data[0];
                    string position = data[1];
                    int skill = int.Parse(data[2]);
                    if (!playerStats.ContainsKey(player))
                    {
                        Dictionary<string, int> assistDictionary = new Dictionary<string, int>();
                        assistDictionary.Add(position, skill);
                        playerStats[player] = assistDictionary;
                    }
                    if (playerStats.ContainsKey(player))
                    {
                        if (playerStats[player].ContainsKey(position))
                        {
                            if (skill > playerStats[player][position])
                            {
                                playerStats[player][position] = skill;
                            }
                        }
                        else
                        {
                            playerStats[player].Add(position, skill);
                        }
                    }
                }
                else if (input.Contains(" vs "))
                {
                    string[] data = input.Split(" vs ");
                    string player1 = data[0];
                    string player2 = data[1];
                    if (playerStats.ContainsKey(player1) && playerStats.ContainsKey(player2))
                    {
                        string playerToRemove = string.Empty;
                        foreach (var role in playerStats[player1])
                        {
                            foreach (var pos in playerStats[player2])
                            {
                                if (role.Key == pos.Key)
                                {
                                    int totalPlayer1 = playerStats[player1].Values.Sum();
                                    int totalPlayer2 = playerStats[player2].Values.Sum();
                                    if (totalPlayer1 > totalPlayer2)
                                    {
                                        playerToRemove = player2;
                                    }
                                    else if (totalPlayer2 > totalPlayer1)
                                    {
                                        playerToRemove = player1;
                                    }
                                }
                            }
                        }
                        playerStats.Remove(playerToRemove);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var item in playerStats.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                int total = playerStats[item.Key].Values.Sum();
                Console.WriteLine($"{item.Key}: {total} skill");
                foreach (var info in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {info.Key} <::> {info.Value}");
                }
            }
        }
    }
}