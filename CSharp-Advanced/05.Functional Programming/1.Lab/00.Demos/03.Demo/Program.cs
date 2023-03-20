using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitsOrLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] str = Console.ReadLine().ToCharArray();

            int countDigits = 0;
            int countLetters = 0;

            List<char> chars = str.Where(ch => IsLetterOrDigit(ch) == 2).ToList();
            List<char> digits = str.Where(ch => IsLetterOrDigit(ch) == 1).ToList();

            Console.WriteLine($"The number of characters is: {chars.Count}");
            Console.WriteLine($"The number of digits is: {digits.Count}");
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