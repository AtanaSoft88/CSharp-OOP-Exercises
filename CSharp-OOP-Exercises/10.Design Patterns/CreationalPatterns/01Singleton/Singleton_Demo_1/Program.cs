namespace Singleton_Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //At this point, we can call the Instance property as many times as we want,
            //but our object is going to be instantiated only once and shared for every other call. 
            var data = SingletonData.Instance;
            var data1 = SingletonData.Instance;
            var data2 = SingletonData.Instance;
            var data3 = SingletonData.Instance;
            string countryName = "Bulgaria";
            Console.WriteLine($"Country: {countryName} population is :> {data.GetPopulation(countryName)} <:");
           
        }
    }
}