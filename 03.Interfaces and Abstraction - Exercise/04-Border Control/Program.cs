using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Peter 22 9010101122
            //MK-13 558833251
            //MK-12 33283122
            //End
            //122
            List<string> result = new List<string>();            
            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string[] input = cmd.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (input.Length > 2) // human
                {
                    IEqualAdd human = new Citizen(input[0],int.Parse(input[1]),input[2]);
                    human.AddiD(result);
                }
                else  // robot
                {
                    IEqualAdd robot = new Robot(input[0], input[1]);
                    robot.AddiD(result);
                }

                cmd = Console.ReadLine();
            }
            string magicNum = Console.ReadLine();
            foreach (var id in result)
            {
                if (id.EndsWith(magicNum))
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}
