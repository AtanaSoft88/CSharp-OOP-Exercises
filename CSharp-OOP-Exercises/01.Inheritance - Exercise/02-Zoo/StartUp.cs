using System;
using System.Collections.Generic;

namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Reptile reptile = new Reptile("green reptile");
            List<Reptile> listReptiles = new List<Reptile>();
            listReptiles.Add(reptile);
            reptile.Name = "Big bad lizard";
            Console.WriteLine(reptile.Name);
            reptile = new Snake("Boa");
            listReptiles.Add(reptile);

            foreach (var item in listReptiles)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
