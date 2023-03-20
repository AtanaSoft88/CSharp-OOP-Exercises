namespace Loop_A_Class_GetEnumerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            // 1) Using foreach when we got enumerator in Class Student implemented 
            //foreach (var item in student)
            //{
            //    Console.WriteLine(item);
            //}


            // 2) Writing our own enumerator implementation
            //How does this foreach over a Class work? See below without foreach
            var enumerator = student.GetEnumerator();
            enumerator.Reset(); // This method let the iteration to start from element 0
            while (enumerator.MoveNext()) // till we have elements to iterate through
            {
                var item = enumerator.Current;
                Console.WriteLine(item);
            }
        }
    }
}