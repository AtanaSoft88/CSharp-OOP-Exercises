using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] namesAndAdress = Console.ReadLine().Split();
            string firstName = namesAndAdress[0];
            string lastName = namesAndAdress[1];
            string firstPart = $"{string.Join(" ", firstName, lastName)}";
            string secondPart = namesAndAdress[2];
            string town = string.Empty;
            if (namesAndAdress.Length == 5)
            {
                town = $"{string.Join(" ", namesAndAdress[3], namesAndAdress[4])}";
            }
            if (namesAndAdress.Length == 4)
            {
                town = namesAndAdress[3];
            }


            string[] nameAndLiters = Console.ReadLine().Split();
            string name = nameAndLiters[0];
            int liters = int.Parse(nameAndLiters[1]);
            bool drunkOrNot = false;
            if (nameAndLiters[2] == "drunk")
            {
                drunkOrNot = true;
            }

            string[] accBankBalance = Console.ReadLine().Split();
            string nameAcc = accBankBalance[0];
            double numDouble = double.Parse(accBankBalance[1]);
            string nameBank = accBankBalance[2];

            

            Threeuple<string, string, string> tupleOne = new Threeuple<string, string, string>();
            tupleOne.Item1 = firstPart;
            tupleOne.Item2 = secondPart;
            tupleOne.Item3 = town;
            
            Threeuple<string, int, bool> tupleTwo = new Threeuple<string, int, bool>();
            tupleTwo.Item1 = name;
            tupleTwo.Item2 = liters;
            tupleTwo.Item3 = drunkOrNot;


            Threeuple<string, double , string> tupleThree = new Threeuple<string, double, string>();
            tupleThree.Item1 = nameAcc;
            tupleThree.Item2 = numDouble;
            tupleThree.Item3 = nameBank;


            tupleOne.GetTupleItems();
            tupleTwo.GetTupleItems();
            tupleThree.GetTupleItems();
        }
    }
}
