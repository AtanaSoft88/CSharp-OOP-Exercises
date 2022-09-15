using System;
using System.IO;
using System.Text.Json;
namespace _00.Demo_Json
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //System.Text.Json

            Car car = new Car() 
            { 
                Model="Golf",
                Color="Blue",
                Description="Best car ever!",
                ManufacturedOn =DateTime.Now.AddYears(-13),
                Extras = 
                {
                    "Economic Engine, Diesel Power, Climatronic, Sound System" 
                },
                Engine = new Engine
                {
                    HP=105,Volume=1900M
                },
                Price = 8603.58M

            };

            //With Classes in C# we describe Json format which can be read by another Programming language (JS , Python , etc)!
            //We have finished Object and want to extract it on a JSON , using "System.Text.Json" from NuGet Packages
            var options = new JsonSerializerOptions {WriteIndented = true };
            var jsonWithOptions = JsonSerializer.Serialize(car, options);
            Console.WriteLine(jsonWithOptions);
            Console.WriteLine();
            Console.WriteLine(new String('*', 60));

            //We need just json default formating
            var jsonDefaultFormat= JsonSerializer.Serialize(car);
            Console.WriteLine();
            Console.WriteLine(jsonDefaultFormat);


            //We want to Save it into file , and with nice sort of the text , using System.IO;
            File.WriteAllText("..//..//..//TxtFileTest.txt",JsonSerializer.Serialize(car, options));
            File.WriteAllText("..//..//..//JsonFileTest.json",JsonSerializer.Serialize(car, options));

            //Reverse operation to get from Json file on our local hdd the object extracted

            var jsonFile = File.ReadAllText("..//..//..//JsonFileTest.json");
            Car carFromJsonDefault = JsonSerializer.Deserialize<Car>(jsonFile);
            Car carFromJsonWithOptions = JsonSerializer.Deserialize<Car>(jsonFile,options);



            //How to parse a json into C# without having the classes and properties?!
            
        }
    }
}
