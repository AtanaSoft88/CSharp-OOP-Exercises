using System;
using System.Collections.Generic;
using System.Text;

namespace Obtain_Interfaces_Reflection
{
    public class Car:ICar,IRepairable
    {
        private const int initialKm = 50_000;
        private int somePrivateField1 = 10;
        private int somePrivateField2 = 20;
        private int somePrivateField3 = 30;
        public int fieldTest;
        public int fieldTest1;
        public int fieldTest2;
        private string name = "Gogo";
        private string name1 = "Lolo";
        public Car(string name)
        {
            this.name = name;
        }
        public Car(int kilometers,string model, int age, int hP)           
        {
            Kilometers = kilometers;
            Model = model;            
            Age = age;
            HP = hP;            
        }
        
        public int Kilometers { get; set; }
        public string Model { get;}        
        public int Age { get;}
        public int HP { get;}
        public bool isOldCar { get; set; }
        public void Drive(int distance)
        {
            Kilometers += distance;
            if (Kilometers >= 100000)
            {
                Console.WriteLine("The car is above 100k and is old");
                RepairMe(distance);
                isOldCar = true;
            }
            else
            {
                Console.WriteLine("So much distance to run. The car is perfect");
            }
        }       

        public void RepairMe(int distance)
        {
            Console.WriteLine("Car needs to be repaired!");
            Console.WriteLine("Now kilometers are set to 50_000");
            Kilometers = initialKm + distance;
        }
        public void PublicTestMethod()
        {

        }
        public void RepairTestMethod()
        {
            
        }
    }
}
