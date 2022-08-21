using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Cards
{
    public class Card
    {
        public Card()
        {
            this.faceCards = new List<string> {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            this.suitCards = new List<char> { 'S','H','D','C' };
        }

        public List<string> faceCards { get;}
        public List<char> suitCards { get;}

        public string CreateCard(string face, char suitCharacter)
        {
            string result = string.Empty;
            string validFace = faceCards.FirstOrDefault(x => x == face);
            char validSuit = suitCards.FirstOrDefault(x => x == suitCharacter);
            if (validFace != null && validSuit != '\u0000')
            {                
                if (suitCharacter == 'S')
                {
                    suitCharacter = '\u2660';
                }
                else if (suitCharacter == 'H')
                {
                    suitCharacter = '\u2665';
                }
                else if (suitCharacter == 'D')
                {
                    suitCharacter = '\u2666';
                }
                else if (suitCharacter == 'C')
                {
                    suitCharacter = '\u2663';
                }

                result = $"[{face}{suitCharacter}]";
            }
            
            return result;
        }
    }
}
