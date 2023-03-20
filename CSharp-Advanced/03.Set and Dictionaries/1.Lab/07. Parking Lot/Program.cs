using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();
            HashSet<string> setCarReg = new HashSet<string>();
            while (cmd != "END")
            {
                string[] carID = cmd.Split(", ");
                if (carID[0] == "IN")
                {
                    setCarReg.Add(carID[1]);
                }
                else
                {
                    setCarReg.Remove(carID[1]);
                }

                cmd = Console.ReadLine();
            }
            if (setCarReg.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var id in setCarReg)
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}
