using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop_A_Class_GetEnumerator
{
    public class Student : IEnumerable<double> // implement IEnumerable<T> and below 2 methods appeared -> first is the most important.
    {
        public Student()
        {
            Grades = new List<double>() {2.5,3.6,5.6,5.9,3.1 };
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<double> Grades { get; set; }

        public IEnumerator<double> GetEnumerator()
        {
            //when i foreach the Student class i get what i have implemented here.
            return this.Grades.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
