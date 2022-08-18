using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Citizen Peter 22 9010101122 10/10/1990 - 5
            //Pet Sharo 13/11/2005    - 3
            //Robot MK-13 558833251 - 3
            //End
            //1990
            List<IIdentible> test = new List<IIdentible>();
            List<string> birthList = new List<string>();
            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string[] input = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Citizen") // human
                {
                    IIdentible human = new Citizen(input[1], int.Parse(input[2]), input[3],input[4]);                    
                    human.AddBirthDate(birthList);
                    test.Add(human);

                }
                else if(input[0] == "Pet")  // robot
                {
                    IIdentible pet = new Pet(input[1], input[2]);
                    pet.AddBirthDate(birthList);
                    test.Add(pet);
                }

                cmd = Console.ReadLine();
            }
            string magicNum = Console.ReadLine();
            //foreach (var birth in birthList)
            //{
            //    if (birth.EndsWith(magicNum))
            //    {                    
            //        Console.WriteLine(birth);
            //    }
            //}
            foreach (var item in test)
            {
                if (item.Birthdate.EndsWith(magicNum))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }
    }
}
