using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
       private int capacity;
       private Dictionary<string,Car> parkingCarsDict;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            parkingCarsDict = new Dictionary<string, Car>(); //!!!!
        }

        public int Count 
        {
            get 
            {
               return parkingCarsDict.Count; 
            }
            
            
        }

        public string AddCar(Car car)
        {
            if (parkingCarsDict.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (parkingCarsDict.Count == capacity)
            {
                return "Parking is full!";
            }

            parkingCarsDict.Add(car.RegistrationNumber,car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }

        public string RemoveCar(string registrationNumber)
        {
            if (!parkingCarsDict.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            parkingCarsDict.Remove(registrationNumber);
            return $"Successfully removed {registrationNumber}";



        }

        public Car GetCar(string registrationNumber)
        {
            
            return parkingCarsDict.FirstOrDefault(x => x.Key == registrationNumber).Value;



        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var reg in registrationNumbers)
            {
                parkingCarsDict.Remove(reg);
            }
        
        
        }
    }
}
