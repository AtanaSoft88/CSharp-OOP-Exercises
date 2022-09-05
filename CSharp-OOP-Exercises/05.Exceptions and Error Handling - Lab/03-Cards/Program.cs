using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	\u2660 – Spades(♠)
            //•	\u2665 – Hearts(♥)
            //•	\u2666 – Diamonds(♦)
            //•	\u2663 – Clubs(♣)
            //•	\u0000 – char = 0
            // A S, 10 D, K H, 2 C

            string[] inputCards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<string> result = new List<string>();
            foreach (var parts in inputCards)
            {                
                string face = parts.Split()[0];
                char suit = '\u0000';

                bool isChar = char.TryParse(parts.Split()[1], out var resultChar);
                Card card = new Card();
                try
                {
                    if (isChar)
                    {
                        suit = resultChar;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid card!");
                    }

                    string currentCard = card.CreateCard(face, suit);

                    if (currentCard == string.Empty)
                    {
                        throw new ArgumentException("Invalid card!");
                    }
                    else
                    {
                        result.Add(currentCard);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
            Console.WriteLine(string.Join(" ", result));

        }
        
    }
}
