using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {         

            string[] input = Console.ReadLine().Split();

            Dictionary<string, Dictionary<string, HashSet<string>>> followingInfo = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            
            while (input[0] != "Statistics")
            {
                string baseName = input[0];

                if (input[1] == "joined")
                {
                    if (!followingInfo.ContainsKey(baseName))
                    {
                        followingInfo.Add(baseName, new Dictionary<string, HashSet<string>>());
                        followingInfo[baseName].Add("followers",new HashSet<string>());
                        followingInfo[baseName].Add("following",new HashSet<string>());
                    }
                    
                }
                else
                {
                    string followedName = input[2];
                    if (baseName == followedName)
                    {
                        input = Console.ReadLine().Split();
                        continue;
                    }
                    if (followingInfo.ContainsKey(baseName) && followingInfo.ContainsKey(followedName))
                    {
                        followingInfo[baseName]["following"].Add(followedName);
                        followingInfo[followedName]["followers"].Add(baseName);
                    }
                    
                }

                input = Console.ReadLine().Split();

            }
            Console.WriteLine($"The V-Logger has a total of {followingInfo.Count()} vloggers in its logs.");
            int count = 0;
            int maxValue = 0;
            foreach (var kvp in followingInfo.OrderByDescending(x=>x.Value["followers"].Count()).ThenBy(x=>x.Value["following"].Count()))
            {
                if (kvp.Value["followers"].Count() > maxValue)
                {
                    maxValue = kvp.Value["followers"].Count();
                    Console.WriteLine($"{++count}. {kvp.Key} : {kvp.Value["followers"].Count()} followers, {kvp.Value["following"].Count()} following");
                    foreach (var item in kvp.Value["followers"].OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
                else
                {
                    Console.WriteLine($"{++count}. {kvp.Key} : {kvp.Value["followers"].Count()} followers, {kvp.Value["following"].Count()} following");
                }
            }

        }
    }
}
