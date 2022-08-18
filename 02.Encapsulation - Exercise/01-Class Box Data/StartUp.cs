using System;

namespace ClassBoxData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Volume = lwh
            //Lateral Surface Area = 2lh + 2wh
            //Surface Area = 2lw + 2lh + 2wh          
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());                       
            
            double volume = 0;
            double lateralSurfaceArea = 0;
            double surfaceArea = 0;
            try
            {
                Box box = new Box(length, width, heigth);
                volume = box.Volume(length, width, heigth);
                lateralSurfaceArea = box.LateralSurfaceArea(length, width, heigth);
                surfaceArea = box.SurfaceArea(length, width, heigth);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }

            Console.WriteLine($"Surface Area - {surfaceArea:f2}");
            Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
            Console.WriteLine($"Volume - {volume:f2}");
            //Surface Area - 52.00
            //Lateral Surface Area - 40.00
            //Volume - 24.00


        }
    }
}
