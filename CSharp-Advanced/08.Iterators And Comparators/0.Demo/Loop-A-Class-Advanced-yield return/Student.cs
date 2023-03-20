using Loop_A_Class_Advanced_Enumerator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop_A_Class_GetEnumerator
{
    public class Student : IEnumerable<string> // implement IEnumerable<T> and below 2 methods appeared -> first is the most important.
    {
        private readonly List<string> studentProperties;
        public Student(string id, string name, string currentGrade)
        {
            this.Id = id;
            this.Name = name;
            this.CurrentGrade = currentGrade;
            Grades = new List<double>() {2.5,3.6,5.6,5.9,3.1 };
            studentProperties = new List<string>() { this.Id, this.Name, this.CurrentGrade , String.Join("\r\n", this.Grades)};
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string CurrentGrade { get; set; }
        public List<double> Grades { get; set; }

        public IEnumerator<string> GetEnumerator()
        {
            // When i want simple implementation i can achieve it by yield return ( no need separate Enumeration Logic class)
            for (int i = 0; i < studentProperties.Count(); i++)
            {
                yield return studentProperties[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
