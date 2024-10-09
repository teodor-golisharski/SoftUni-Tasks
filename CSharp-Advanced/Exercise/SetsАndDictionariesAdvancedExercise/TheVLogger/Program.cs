using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, VloggerData> data = new Dictionary<string, VloggerData>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split();
                string vloggerName = tokens[0];
                string command = tokens[1];
                if (command == "joined")
                {
                    if (!data.ContainsKey(vloggerName))
                    {
                        data.Add(vloggerName, new VloggerData(new HashSet<string>(), new HashSet<string>()));
                    }
                }
                else if (command == "followed")
                {
                    string secondVlogger = tokens[2];
                    if (data.ContainsKey(vloggerName) && data.ContainsKey(secondVlogger))
                    {
                        if (vloggerName != secondVlogger)
                        {

                            data[vloggerName].Following.Add(secondVlogger);
                            data[secondVlogger].Followers.Add(vloggerName);
                        }
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {data.Count} vloggers in its logs.");
            int count = 1;
            foreach (var item in data.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count))
            {
                Console.WriteLine($"{count}. {item.Key} : {item.Value.Followers.Count} followers, {item.Value.Following.Count} following");
                if (count == 1)
                {
                    foreach (var followers in item.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {followers}");
                    }
                }
                count++;
            }
        }
    }
    class VloggerData
    {
        public VloggerData(HashSet<string> following, HashSet<string> followers)
        {
            this.Following = following;
            this.Followers = followers;
        }

        public HashSet<string> Following { get; set; }
        public HashSet<string> Followers { get; set; }
    }
}
