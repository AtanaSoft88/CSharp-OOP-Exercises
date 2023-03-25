using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web.HTTP.Enums;
using HttpStatusCode = Web.HTTP.Enums.HttpStatusCode;

namespace Web.HTTP
{
    public class HttpResponse
    { // Contains what we would return to the Client -> Headers and data we want to return to the Client
        //default status code we set to OK
        
        public HttpResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();
            BodyResponse = new byte[0];

        }
        public HttpResponse(string contentType, byte[] body, Enums.HttpStatusCode statusCode = Enums.HttpStatusCode.OK) 
        {
            if (body == null) 
            {
                body = new byte[0];
            }
            this.StatusCode = statusCode;
            this.BodyResponse = body;
            this.Cookies = new List<Cookie>();
            this.Headers = new List<Header>           
            {                
                new Header("Content-Type", contentType),
                new Header("Content-Length", body.Length.ToString())               
            };

            
        }
        public HttpStatusCode StatusCode { get; set; }
        public ICollection<Header> Headers { get; set; }
        public ICollection<Cookie> Cookies { get; set; }
        public byte[] BodyResponse { get; set; }

        public override string ToString()
        {
            StringBuilder sbResponse = new StringBuilder();
            sbResponse.Append($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode.ToString()}" + HttpConstants.NewLine);
            foreach (var header in this.Headers)
            {
                sbResponse.Append(header.ToString() + HttpConstants.NewLine);
            }

            foreach (var cookie in this.Cookies)
            {
                sbResponse.Append("Set-Cookie: " + cookie.ToString() + HttpConstants.NewLine);
            }

            sbResponse.Append(HttpConstants.NewLine);
            return sbResponse.ToString();
        }
    }
}
