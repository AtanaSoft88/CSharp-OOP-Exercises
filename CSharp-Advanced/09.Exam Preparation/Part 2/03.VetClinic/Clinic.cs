using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
       private List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            Data = data = new List<Pet>();
        }

        public int Capacity { get; set; }
        public List<Pet> Data { get; set; }

        public int Count { get => Data.Count; }

        public void Add(Pet pet)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(pet);
            }
        
        }
        public bool Remove(string name)
        {            
            Pet pet = Data.FirstOrDefault(x=>x.Name == name);
            if (pet != null)
            {
               return Data.Remove(pet);
            }
            return false;       
        
        }
        public Pet GetPet(string name, string owner)
        {
            Pet pet = Data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
            if (pet == null)
            {
                return null;
            }
            return pet;       
        
        }

        public Pet GetOldestPet()
        {
            Pet pet = Data.OrderByDescending(x => x.Age).FirstOrDefault();

            return pet;       
        
        }

        public string GetStatistics()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in Data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }           

            return sb.ToString();
        
        
        }

    }
}
