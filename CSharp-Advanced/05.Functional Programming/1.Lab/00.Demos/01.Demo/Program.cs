using System;

namespace DigitsOrLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            int countDigits = 0;
            int countLetters = 0;


            foreach (char ch in str)
            {
                int symbol = IsLetterOrDigit(ch);

                switch (symbol)
                {
                    case 1:
                        countDigits++;
                        break;
                    case 2:
                        countLetters++;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"The number of characters is: {countLetters}");
            Console.WriteLine($"The number of digits is: {countDigits}");
        }

        static Func<char, int> IsLetterOrDigit = (sh) =>
        {
            if (char.IsDigit(sh))
            {
                return 1;
            }

            if (char.IsLetter(sh))
            {
                return 2;
            }

            return 3;
        };// IsLetterOrDigit = (sh,)
    }
}