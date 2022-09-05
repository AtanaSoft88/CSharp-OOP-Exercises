using System;

namespace _04.SumofIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] numbersToCheck = Console.ReadLine().Split();
            int sum = 0;
            foreach (var num in numbersToCheck)
            {
                bool isParsableToInt = long.TryParse( num, out long result);                
                try
                {
                    if (isParsableToInt)
                    {
                        if (long.Parse(num) <= int.MaxValue)
                        {
                            sum += int.Parse(num);
                        }
                        else
                        {
                            throw new OverflowException($"The element '{num}' is out of range!");
                        }

                    }
                    else
                    {
                        throw new FormatException($"The element '{num}' is in wrong format!");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine($"Element '{num}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
