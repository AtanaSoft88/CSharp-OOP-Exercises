using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
                //EmilConrad joined The V-Logger
                //VenomTheDoctor joined The V-Logger
                //Saffrona joined The V-Logger
                //Saffrona followed EmilConrad
                //Saffrona followed VenomTheDoctor
                //EmilConrad followed VenomTheDoctor
                //VenomTheDoctor followed VenomTheDoctor
                //Saffrona followed EmilConrad
                //Statistics

            string[] input = Console.ReadLine().Split();
            HashSet<string> joinedInfo = new HashSet<string>();
            Dictionary<string, List<string>> following = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> followed = new Dictionary<string, List<string>>();
            while (input[0] != "Statistics")
            {
                string baseName = input[0];

                if (input[1] == "joined")
                {
                    if (!following.ContainsKey(baseName))
                    {
                        following.Add(baseName,new List<string>());
                        
                    }
                    if (!followed.ContainsKey(baseName))
                    {
                        followed.Add(baseName, new List<string>());
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
                    if (following.ContainsKey(baseName) && following.ContainsKey(followedName))
                    {
                        if (!following[baseName].Contains(followedName))
                        {
                            following[baseName].Add(followedName);

                        }
                    }
                    if (followed.ContainsKey(baseName) && followed.ContainsKey(followedName))
                    {

                        if (!followed[followedName].Contains(baseName))
                        {
                            followed[followedName].Add(baseName);
                        }
                        
                    }
                    

                }
                


                input = Console.ReadLine().Split();
            
            
            }
            Console.WriteLine($"The V-Logger has a total of {following.Count()} vloggers in its logs.");
            int count = 0;
            int maxValue = 0;
            foreach (var kvp in followed.OrderByDescending(x=>x.Value.Count()).ThenBy(x => following.Values.Count()))
            {
                if (kvp.Value.Count() > maxValue)
                {
                    maxValue = kvp.Value.Count();
                    Console.WriteLine($"{++count}. {kvp.Key} : {kvp.Value.Count()} followers, {following[kvp.Key].Count()} following");
                    foreach (var item in kvp.Value.OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
                else
                {
                    Console.WriteLine($"{++count}. {kvp.Key} : {kvp.Value.Count()} followers, {following[kvp.Key].Count()} following");
                }
            }

        }
    }
}
