using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> studentsInfo = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string command = Console.ReadLine();

            while (command != "end of contests")
            {
                string[] inputContests = command.Split(':',StringSplitOptions.RemoveEmptyEntries);
                string password = inputContests[1];
                if (!contests.ContainsKey(inputContests[0]))
                {
                    contests.Add(inputContests[0], password);
                }                        

                command = Console.ReadLine();
            }

            string cmd = Console.ReadLine();
            
            while (cmd != "end of submissions")
            {
                string[] inputCmd = cmd.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string course = inputCmd[0];
                string passwordForExam = inputCmd[1];
                string studenName = inputCmd[2];
                int grade = int.Parse(inputCmd[3]);
                
                if (contests.ContainsKey(course) && contests.Values.Contains(passwordForExam))
                {
                    if (!studentsInfo.ContainsKey(studenName))
                    {
                        studentsInfo.Add(studenName, new Dictionary<string, int>());
                                                
                    }
                    if (!studentsInfo[studenName].ContainsKey(course))
                    {
                        studentsInfo[studenName].Add(course, grade);
                        
                    }
                    else
                    {
                        int oldGrade = studentsInfo[studenName][course];
                        if (oldGrade < grade)
                        {
                            studentsInfo[studenName][course] = grade;
                        }
                        else
                        {
                            studentsInfo[studenName][course] = oldGrade;
                        }
                    }

                }

                cmd = Console.ReadLine();

            }
            int maxPoints = 0;
            string bestCandidate = string.Empty;
            foreach (var student in studentsInfo)
            {
                int currentScore = student.Value.Sum(x=>x.Value);
                if (currentScore > maxPoints)
                {
                    maxPoints = currentScore;
                    bestCandidate = student.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestCandidate} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var studentRank in studentsInfo.OrderBy(x=>x.Key))
            {
                Console.WriteLine(studentRank.Key);
                foreach (var item in studentRank.Value.OrderByDescending(p=>p.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }

        }
    }
}
