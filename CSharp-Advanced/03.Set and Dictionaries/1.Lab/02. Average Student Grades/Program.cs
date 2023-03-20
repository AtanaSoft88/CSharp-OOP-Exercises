using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] student = Console.ReadLine().Split();
                string name = student[0];
                decimal grade = decimal.Parse(student[1]);
                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades.Add(name, new List<decimal>());
                }
                studentGrades[name].Add(grade);

            }
            foreach (var item in studentGrades)
            {

                Console.WriteLine($"{item.Key} -> {string.Join(" ", item.Value.Select(x => x.ToString("f2")))} (avg: {item.Value.Average():f2})");
            }
        }
    }
}