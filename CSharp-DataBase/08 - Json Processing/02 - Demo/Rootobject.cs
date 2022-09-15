using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Demo_Json_Newton
{
    // First Delete the Default Data , you have to see only the namespace {} and click inside the body.
    //Then copy the Json file you want to paste here and go : Visual Studio Edit -> Paste Special -> "Paste Json as Classes" 
    //We have all the classes/properties extracted from Json to C# Classes/properties - ready to be used as Rootobject Class
    public class Rootobject
    {
        internal const string test = @"{
                        ""name"": ""John"",
                        ""age"": 22,
                        ""hobby"": 
                         {
	                    ""reading"" : true,
	                    ""gaming"" : false,
	                    ""sport"" : ""football""
                         },
                        ""Class"" : [""JavaScript"", ""HTML"", ""CSS""]
        }";

        public string name { get; set; }
        public int age { get; set; }
        public Hobby hobby { get; set; }
        public string[] Class { get; set; }
    }

    public class Hobby
    {
        public bool reading { get; set; }
        public bool gaming { get; set; }
        public string sport { get; set; }
    }



}
