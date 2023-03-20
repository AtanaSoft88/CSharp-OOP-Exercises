using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> studentsInfo = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            string cmd = Console.ReadLine();

            while (cmd != "exam finished")
            {
                string[] inputCmd = cmd.Split("-",StringSplitOptions.RemoveEmptyEntries);
                                
                if (inputCmd[1] == "banned" && studentsInfo.ContainsKey(inputCmd[0]))
                {                                        
                    studentsInfo.Remove(inputCmd[0]);
                    cmd = Console.ReadLine();
                    continue;
                }
                
                string name = inputCmd[0];
                string module = inputCmd[1];
                int scorePts = int.Parse(inputCmd[2]);

                if (!studentsInfo.ContainsKey(name))
                {
                    studentsInfo.Add(name,new Dictionary<string, int>());
                }
                if (!studentsInfo[name].ContainsKey(module))
                {
                    studentsInfo[name].Add(module, scorePts);
                }

                int previousPoints = studentsInfo[name][module];

                if (previousPoints >= scorePts)
                {
                    studentsInfo[name][module] = previousPoints;
                }
                else
                {
                    studentsInfo[name][module] = scorePts;
                }
                if (!submissions.ContainsKey(module))
                {
                    submissions.Add(module,0);
                }
                submissions[module]++;

                cmd = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            foreach (var item in studentsInfo.OrderByDescending(x=>x.Value.Values.Max()).ThenBy(n=>n.Key))
            {
                foreach (var kvp in item.Value)
                {
                    Console.WriteLine($"{item.Key} | {kvp.Value}");
                }
            }
            Console.WriteLine("Submissions:");
            foreach (var module in submissions.OrderByDescending(x => x.Value).ThenBy(k=>k.Key))
            {
                Console.WriteLine($"{module.Key} - {module.Value}");
            }
        }
    }
}
