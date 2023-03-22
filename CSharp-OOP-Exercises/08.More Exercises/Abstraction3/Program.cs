using System.Reflection;

namespace Abstraction3
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            var deviceList = new ElectronicDevice();
            deviceList.AddDevice(new Laptop("Legion 5 pro", 100, new Random().Next(1, 101)));
            deviceList.AddDevice(new Phone("Samsung Galaxy Z Pro", 100, new Random().Next(1, 101)));
            foreach (var item in deviceList.Items)
            {
                if (item is Laptop)
                {
                    var currentLaptop = item as Laptop;
                    Console.WriteLine($".--== {currentLaptop.Model} ==--.");
                    Console.WriteLine($"Current Device has {item.DisplayBatteryPercentage()} percentage battery");
                    Console.WriteLine(currentLaptop.WatchMovie());
                    Console.WriteLine(currentLaptop.ChargeBattery());
                }
                else
                {
                    var currentPhone = item as Phone;
                    Console.WriteLine($".--== {currentPhone.Model} ==--.");
                    Console.WriteLine($"Current Device has {item.DisplayBatteryPercentage()} percentage battery");
                    Console.WriteLine(currentPhone.Talk());
                    Console.WriteLine(currentPhone.WatchMovie());
                    Console.WriteLine($"Current Device has {item.DisplayBatteryPercentage()} percentage battery");
                    Console.WriteLine(currentPhone.ChargeBattery());
                }
                
                Console.WriteLine(new string('*',60));
            }

        }
    }
}