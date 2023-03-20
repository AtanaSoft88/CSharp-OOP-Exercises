using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {              

        public Classroom(int capacity)
        {
            this.Students = new List<Student>();
            this.Capacity = capacity;
            
        }
        public List<Student> Students { get; set ; }
        public int Capacity { get; set; }
        public int Count => Students.Count;

        public string RegisterStudent(Student student)
        {
            
            if (Students.Count >= Capacity)
            {
                return "No seats in the classroom";               
                                
            }
            Students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";



        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (student == null)
            {
                return"Student not found";
            }
            Students.Remove(student);
            return $"Dismissed student {student.FirstName} {student. LastName}";


        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            
            if (Students.Any(x=>x.Subject==subject))
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var person in Students)
                {
                    if (person.Subject == subject)
                    {
                        sb.AppendLine($"{person.FirstName} {person.LastName}");
                    }

                }

                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";

        }

        public int GetStudentsCount()
        {
            return Students.Count();
        
        
        }

        public Student GetStudent(string firstName, string lastName)
        {


            return Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
