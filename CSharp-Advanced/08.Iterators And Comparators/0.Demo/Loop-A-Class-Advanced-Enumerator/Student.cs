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
            studentProperties = new List<string>() { this.Id, this.Name, this.CurrentGrade };
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string CurrentGrade { get; set; }
        public List<double> Grades { get; set; }

        public IEnumerator<string> GetEnumerator()
        {
            //when i foreach the Student class (Example: all string properties) i get what i have implemented here.
            return new EnumerationLogic(studentProperties);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
