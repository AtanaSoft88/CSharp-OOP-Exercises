using Loop_A_Class_GetEnumerator;

namespace Loop_A_Class_Advanced_Enumerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("No:743", "Pesho", "IV Course");
            //Below is the logic where i implement foreach loop using the Student properties which are strings to loop through

            //var enumerator = student.GetEnumerator();
            //enumerator.Reset();
            //while (enumerator.MoveNext())
            //{
            //    var element = enumerator.Current;
            //    Console.WriteLine(element);
            //}


            //Now just foreach the Student
            foreach (var item in student)
            {
                Console.WriteLine(item);
            }
        }
    }
}