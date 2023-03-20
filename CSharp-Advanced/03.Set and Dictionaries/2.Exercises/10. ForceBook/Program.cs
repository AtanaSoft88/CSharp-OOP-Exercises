using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();                      

            Dictionary<string, Dictionary<string, int>> forceSide = new Dictionary<string, Dictionary<string, int>>();
            string sideLight = string.Empty;
            string sideDark = string.Empty;
            while (cmd!= "Lumpawaroo")
            {
                string[] input = cmd.Split(new string[] {" | ", " -> "},StringSplitOptions.RemoveEmptyEntries);
                
                
                if (cmd.Contains(" | "))
                {
                    
                    string name = input[1];
                    if (input[0].Contains("Light"))
                    {
                        sideLight = input[0];
                        if (!forceSide.ContainsKey(sideLight))
                        {
                            forceSide.Add(sideLight, new Dictionary<string, int>());
                        }
                        if (!forceSide[sideLight].ContainsKey(name))
                        {
                            forceSide[sideLight].Add(name,1);
                        }

                        
                    }
                    else
                    {
                        sideDark = input[0];

                        if (!forceSide.ContainsKey(sideDark))
                        {
                            forceSide.Add(sideDark, new Dictionary<string, int>());
                        }
                        if (!forceSide[sideDark].ContainsKey(name))
                        {
                            forceSide[sideDark].Add(name, 1);
                        }

                    }
                }
                else if (cmd.Contains(" -> "))
                {
                    string name = input[0];

                    if (input[1].Contains("Light"))
                    {
                        sideLight = input[1];
                        if (forceSide[sideLight].ContainsKey(name))
                        {
                            forceSide[sideLight].Remove(name);
                            forceSide[sideDark].Add(name, 1);
                            Console.WriteLine($"{name} joins the {sideDark} side!");
                        }
                        else
                        {
                            forceSide[sideLight].Add(name, 1);
                            Console.WriteLine($"{name} joins the {sideLight} side!");
                            if (forceSide[sideDark].ContainsKey(name))
                            {
                                forceSide[sideDark].Remove(name);
                            }
                        }


                    }
                    else
                    {
                        sideDark = input[1];

                        if (forceSide[sideDark].ContainsKey(name))
                        {
                            forceSide[sideDark].Remove(name);
                            forceSide[sideLight].Add(name, 1);
                            Console.WriteLine($"{name} joins the {sideLight} side!");
                        }
                        else
                        {
                            forceSide[sideDark].Add(name, 1);
                            Console.WriteLine($"{name} joins the {sideDark} side!");
                            if (forceSide[sideLight].ContainsKey(name))
                            {
                                forceSide[sideLight].Remove(name);
                            }
                        }

                    }
                } 
                

                cmd = Console.ReadLine();
            }

            foreach (var kvp in forceSide.OrderByDescending(x=>x.Value.Count()).ThenBy(x=>x.Key))
            {
                
                if (kvp.Value.Count() > 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count()}");
                    foreach (var item in kvp.Value.OrderBy(x=>x.Key))
                    {
                        Console.WriteLine($"! {item.Key}");
                    }
                }
            } 
        }
    }
}
