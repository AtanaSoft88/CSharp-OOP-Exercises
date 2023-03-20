using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            

            string[] namesAndAdress = Console.ReadLine().Split();
            string firstName = namesAndAdress[0];
            string lastName = namesAndAdress[1];

            string[] nameAndLiters = Console.ReadLine().Split();
            string name = nameAndLiters[0];
            int listers = int.Parse(nameAndLiters[1]);

            string[] IntAndDouble = Console.ReadLine().Split();
            int numInt = int.Parse(IntAndDouble[0]);
            double numDouble = double.Parse(IntAndDouble[1]);

            string firstPart= $"{string.Join(" ", firstName, lastName)}";
            string secondPart = namesAndAdress[2];

            Tuple<string,string> tupleStr = new Tuple<string,string>(firstPart, secondPart);
            tupleStr.GetTupleItems();

            Tuple<string, int> tupleStrInt = new Tuple<string, int>(name, listers);
            tupleStrInt.GetTupleItems();

            Tuple<int, double> tupleIntDouble = new Tuple<int, double>(numInt,numDouble);
            tupleIntDouble.GetTupleItems();

        }
    }
}
