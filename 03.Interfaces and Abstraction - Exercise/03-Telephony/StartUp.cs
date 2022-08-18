using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string websites = Console.ReadLine();
        //0882134215 0882134333 0899213421 0558123 3333123
        //shttp://softuni.bg shttp://youtube.com shttp://www.g00gle.com

            string[] arrPhoneNums = numbers.Split(" ",StringSplitOptions.RemoveEmptyEntries); // 5
            string[] arrWebSites = websites.Split(" ",StringSplitOptions.RemoveEmptyEntries); // 3
            Queue<string> queuePhoneNums = new Queue<string>(arrPhoneNums);
            Queue<string> queueWebsites = new Queue<string>(arrWebSites);
            
            while (queuePhoneNums.Count > 0)
            {             
                
                char[] currentNumbers = queuePhoneNums.Peek().ToCharArray();
                if (!currentNumbers.All(x=>char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid number!");
                    queuePhoneNums.Dequeue();
                    continue;
                }                
                if (queuePhoneNums.Peek().Length == 10)
                {
                    ICalling calling = new Smartphone(queuePhoneNums.Peek());
                    calling.Calling();
                    
                }
                else if(queuePhoneNums.Peek().Length == 7)
                {
                    ICalling dialing = new StationaryPhone(queuePhoneNums.Peek());
                    dialing.Calling();
                   
                }
                queuePhoneNums.Dequeue();
            }

            while (queueWebsites.Count > 0)
            {
                IBrowsing browsing = new Smartphone(queueWebsites.Peek());
                char[] currentWeb = queueWebsites.Peek().ToCharArray();                
                if (currentWeb.Any(x=>char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    browsing.Browse();
                    
                }
                queueWebsites.Dequeue();

            }
            
            
        }
    }
}
