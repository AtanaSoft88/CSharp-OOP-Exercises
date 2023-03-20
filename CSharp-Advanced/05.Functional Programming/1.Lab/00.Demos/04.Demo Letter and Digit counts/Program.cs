using System;
using System.Collections.Generic;
using System.Linq;

namespace _002_Demo_Letter_and_Digit_counts
{
    class Program
    {
        static void Main(string[] args)
        {
            //-I was quick to judge him, but it wasn't his fault.
            //- Is this some kind of joke?!Is it ?
            //-Quick, hide here. It is safer.

            string[] inputText = { "-I was quick to judge him, but it wasn't his fault.", "- Is this some kind of joke?!Is it ?", "-Quick, hide here. It is safer." };

            // How many letters and Punctuation there are in each row ?
            int countLetters = 0;
            int countPunctuation = 0;
            List<string> listResult = new List<string>();

            for (int i = 0; i < inputText.Length; i++)
            {
                countLetters = inputText[i].Count(x => char.IsLetter(x));
                countPunctuation = inputText[i].Count(x => char.IsPunctuation(x));
                listResult.Add($"({countLetters})({countPunctuation})");
            }

            for (int i = 0; i < inputText.Length; i++)
            {
                Console.WriteLine($"Line {i + 1}: {inputText[i]} {listResult[i]}");
            }

        }
    }
}
