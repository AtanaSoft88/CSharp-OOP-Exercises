using System;
using System.Collections.Generic;

namespace _02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = new List<int>();
            int start = 1;
            int end = 100;
            int inputNum = 0;
            int currentValidLowerBound = start;
            while (numberList.Count != 10)
            {
                try
                {
                    bool isNumber = int.TryParse(Console.ReadLine(), out var result);
                    if (isNumber)
                    {
                        inputNum = result;

                        if (ReadNumber(start, end, inputNum))
                        {
                            currentValidLowerBound = inputNum;
                            start = inputNum;
                            numberList.Add(inputNum);
                        }
                        else
                        {
                            throw new ArgumentException($"Your number is not in range {currentValidLowerBound} - {end}!");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid Number!");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
            }
            Console.WriteLine(string.Join(", ",numberList));
        }

        private static bool ReadNumber(int start,int end , int checkNumber)
        {
            if (checkNumber > start && checkNumber < end)
            {
                return true;
            }
            return false;

        }
    }
}
