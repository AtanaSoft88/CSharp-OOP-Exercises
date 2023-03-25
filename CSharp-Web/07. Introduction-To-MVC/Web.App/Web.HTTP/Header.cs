using System;

namespace Web.HTTP
{
    public class Header
    {
        public Header(string name,string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public Header(string headerLine)
        { // Example for reading a headerLine : "Cache-Control: max-age=0: sfx0-posn=1: hdr-Ctr-0"
            //Find First part for example "Cache-Control" and everything after that separated by ": " is the second part ( total 2 parts)
            var headerParts = headerLine.Split(new string[] { ": " }, 2 ,StringSplitOptions.None); 

            this.Name = headerParts[0];
            this.Value = headerParts[1];
        }
        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }
    }
}