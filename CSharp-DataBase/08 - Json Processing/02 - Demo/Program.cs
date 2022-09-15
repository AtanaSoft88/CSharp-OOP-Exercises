using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace _01.Demo_Json_Newton
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Newtonsoft.Json

            //If we create custom Json ,we can access any of his objects as if we deserialize it as Object[]

            string jsonObj = @"[45 , true , 45.3, 0.553, false, ""Pesho"" , 56.31 ]";

            var customArray = JsonConvert.DeserializeObject<object[]>(jsonObj);

            foreach (var elem in customArray)
            {
                Console.WriteLine(elem);
            }


            //Create large Random Json file with For loop from Class
            //----------------------------
            Data data = new Data();
           
            List<Data> dataList = new List<Data>();
            dataList = data.ListGenerator();   // Get all the json data into a List                 
            
            string jsonFmData = JsonConvert.SerializeObject(dataList, Formatting.Indented);
            Console.WriteLine(jsonFmData);
            //write string to file
            File.WriteAllText("..//..//..//Files//JsonFromDataFile.json", jsonFmData);


            //Or the slightly more efficient version of the above code(doesn't use a string as a buffer):
            //open file stream
            using (StreamWriter file = File.CreateText("..//..//..//Files//JsonFromDataStream.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                //serialize object directly into file stream    
                serializer.Serialize(file, dataList);
            }
            //----------------------------------------------------------------------------

            Car car = new Car()
            {
                ModelName = "Golf",
                ColorOfTheCar = "Blue",
                Description = "Best car ever!",
                ManufacturedOn = DateTime.Now.AddYears(-16),
                Extras =  // It is ignored in Car's properties by Attribute
                {
                    "Economic Engine, Diesel Power, Climatronic, Sound System"
                },
                Engine = new Engine
                {
                    HP = 105,
                    Volume = 1900M
                },
                Price = 8603.58M
            };

            // Settings the Serialization

            var settings = new JsonSerializerSettings
            {
                // Beautify the output             
                Formatting = Formatting.Indented,
                //casing - using Newtonsoft.Json.Serialization;
                ContractResolver = new DefaultContractResolver
                {
                    // Pascal Case by default - first letter is Upper - for C#
                    NamingStrategy = new DefaultNamingStrategy()

                    //Camel Case - first letter is Lower ,next new word starts with Upper case - for Java Script
                    //NamingStrategy = new CamelCaseNamingStrategy(),

                    // Kebap Case - first letter is Lower ,next new word starts with Lower case , there are "-" between each word
                    //NamingStrategy = new KebabCaseNamingStrategy(),

                    //Snake Case - first letter is Lower ,next new word starts with Lower case , there are "_" between each word
                    //NamingStrategy = new SnakeCaseNamingStrategy(),                    
                },

                //DateTime - Format
                //DateFormatString = "yyyy-MM-dd"


            };

            Console.WriteLine(JsonConvert.SerializeObject(car, settings));



            //Write Json to file no Formatting / SerializeObject from Class Object to json
            File.WriteAllText("..//..//..//Files//JsonFileTest.json", JsonConvert.SerializeObject(car));
            var jsonNoFormatting = JsonConvert.SerializeObject(car);
            Console.WriteLine(jsonNoFormatting);


            //Write Json to file with Formatting / SerializeObject from Class Object to json
            File.WriteAllText("..//..//..//Files//JsonFileTestFormatting.json", JsonConvert.SerializeObject(car, settings));
            var jsonFormatting = JsonConvert.SerializeObject(car, settings);
            Console.WriteLine(jsonFormatting);


            //Write Txt to file with Formatting / SerializeObject from Class Object to string
            File.WriteAllText("..//..//..//Files//TxtFileTest.txt", JsonConvert.SerializeObject(car, settings));
            var txtFormatting = JsonConvert.SerializeObject(car, settings);
            //Console.WriteLine(txtFormatting);


            //Deserialize Anonymous type of Object - instead of creating new Class with properties ,we can use "AnonymousObj" like that.
            File.WriteAllText("..//..//..//Files//JsonFileTestFormatting.json", JsonConvert.SerializeObject(car, settings));
            var jsonFile = File.ReadAllText("..//..//..//Files//JsonFileTestFormatting.json");
            var AnonymousObj = new
            {
                CarModel = "",
                Description = "",
                Price = 0.0M
            };

            Console.WriteLine(JsonConvert.DeserializeAnonymousType(jsonFile, AnonymousObj, settings));

            //Deserializing JSON with JsonConvert - Extract from json file to Class instance , having the Class created and ready for use!
            var jsonDeser = File.ReadAllText("..//..//..//Files//JsonFileTest.json");
            Car deserializedCar = JsonConvert.DeserializeObject<Car>(jsonDeser);


            //Deserializing JSON with JsonConvert - Extract from json file to Class instance WITHOUT Class created by me!
            //Check class Data!
            //In Class Data we extracted the json file as classes : 1) Delete default class 2) VS ->Edit -> Paste Special -> Paste as JSON CLass
            //After we copy same json text now and paste it into notepad. Next we replace all (") with ("") and copy from notepad and paste here as string as below and finally we give that string to the deserializer method using the newly created Rootobject class from json!

            string jsonAsString = Rootobject.test;


            Rootobject obj = JsonConvert.DeserializeObject<Rootobject>(jsonAsString);  // We make Instance of the class
            File.WriteAllText("..//..//..//Files//rootObj.json", JsonConvert.SerializeObject(obj, settings)); // if we want written into File
            var rootObjToJson = JsonConvert.SerializeObject(obj, settings);
            Console.WriteLine(rootObjToJson);






            // using Newtonsoft.Json.Linq; - making Class as a list of elememts
            File.WriteAllText("..//..//..//Files//car.json", JsonConvert.SerializeObject(car, settings));
            var jsonF = File.ReadAllText("..//..//..//Files//car.json");
            //JObject jsonObj1 = JObject.Parse(File.ReadAllText("..//..//..//car.json"));
            JObject jsonObj2 = JObject.Parse(jsonF);
            foreach (var item in jsonObj2.Children())
            {
                Console.WriteLine(item);
                Console.WriteLine(item.ToString().Split(": ")[1]); // getting the value only
                Console.WriteLine("------------");
            }




            //Stream Writer serialize JSON directly to a file
            using (StreamWriter file = File.CreateText("..//..//..//Files//car.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, car);
            }


            //Stream Reader serialize JSON directly to a file
            using (StreamReader file = File.OpenText("..//..//..//Files//car.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                Console.WriteLine(o2);
            }


            // From Json to Xml file - > using System.Xml.Linq;
            var jsonToXml = File.ReadAllText("..//..//..//Files//JsonFileTest.json");
            //XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonToXml, "RootXmlNode");
            //File.WriteAllText("..//..//..//Files//xmlNode.xml", JsonConvert.SerializeXmlNode(doc, Formatting.Indented));

            XNode node = JsonConvert.DeserializeXNode(jsonToXml, "Root");
            File.WriteAllText("..//..//..//Files//xmlXNode.xml", JsonConvert.SerializeXNode(node, Formatting.Indented));
            Console.WriteLine(node);

            //CSV files with Library "CsvHelper" from NuGet package manager
            //We can extract some csv. file from SQL server for example and it will represent table data / can be opened in Excel also            
            //In Sql Server the csv otput file delimiter shall be made to "," instead of ";" , also it should have on top names of columns same as class properties ->>(FirstName,LastName,Salary)
            using var readerXml = new StreamReader("..//..//..//Files//Emp.csv");
            StringBuilder sb = new StringBuilder();

            using var csv = new CsvReader(readerXml, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<ClassForXML>();
            foreach (var item in records)
            {
                sb.AppendLine($"{item.FirstName},{item.LastName}, {item.Salary}");
            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }

    }
}
