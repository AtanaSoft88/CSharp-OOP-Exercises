using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Demo
{
    public class SingletonData : ISingletonContainer
    {
        private static SingletonData instance = new SingletonData();
        private Dictionary<string, int> countries = new Dictionary<string, int>();
        private SingletonData()
        {
            Console.WriteLine("Initializing Singleton object");
            var elements = File.ReadAllText("capitals.txt").Split(", ");
            
            for (int i = 0; i < elements.Length; i++)
            {
                countries.Add(elements[i].Split()[0], int.Parse(elements[i].Split()[1]));
            }
        }
        public static SingletonData Instance => instance;
        public int GetPopulation(string name)
        {
            return countries[name];
        }
    }
}
