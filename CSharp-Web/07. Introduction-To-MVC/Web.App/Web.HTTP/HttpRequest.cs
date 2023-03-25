using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.HTTP.Enums;

namespace Web.HTTP
{
    public class HttpRequest
    {
        //This class preserves infrormation came from Client ( type Request , list of Headers , data sent by the Client)
        public HttpRequest(string requestString) // from this requestString to get the Properties below
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();

            StringParser(requestString); // it assigns - Path, Method and Body
        }

        public string Path { get; set; }
        public TypeMethod Method { get; set; } //GET/POST...
        public string Body { get; set; }
        public ICollection<Header> Headers { get; set; }
        public ICollection<Cookie> Cookies { get; set; }




        private void StringParser(string requestString)
        {
            string[] lines = requestString.Split(new string[] { HttpConstants.NewLine }, StringSplitOptions.None);

            //"headerLine" =>  "GET /someAddressPage-Path HTTP/1.1
            string headerLine = lines[0];
            string[] headerLineParts = headerLine.Split(' ');

            this.Method = Enum.Parse<TypeMethod>(headerLineParts[0],ignoreCase:true); // GET/POST/DELETE/UPDATE
            this.Path = headerLineParts[1]; // /someAddressPage-Path

            int lineIndex = 1;
            bool isInHeaders = true;
            StringBuilder bodySb = new StringBuilder();

            //While loop for parsing Header and Body
            while (lineIndex < lines.Length)
            {
                var line = lines[lineIndex];
                lineIndex++;

                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeaders = false;
                    continue;
                }

                if (isInHeaders)  //Read/Add header
                {
                    this.Headers.Add(new Header(line));
                }
                else //Read/Add Body
                {
                    bodySb.AppendLine(line);
                }

                if (this.Headers.Any(c=>c.Name == HttpConstants.RequestCookieHeader))
                {
                    string cookiesAsString = this.Headers.FirstOrDefault(x => x.Name == HttpConstants.RequestCookieHeader).Value;
                    string[] cookies = cookiesAsString.Split("; ",StringSplitOptions.RemoveEmptyEntries);
                    foreach (var cookieAsString in cookies)
                    {
                        this.Cookies.Add(new Cookie(cookieAsString));
                    }
                }

            }
            this.Body = bodySb.ToString();
        }

       
    }
}
