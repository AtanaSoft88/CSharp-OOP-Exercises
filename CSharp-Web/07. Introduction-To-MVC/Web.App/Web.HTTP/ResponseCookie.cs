using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.HTTP
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string name , string value)
            :base(name, value)
        {
            // we get from the Base constructor the data about "name" and "value"
            this.Path = "/";
        }
        //Each Cookie can have attributes for example : Max-Age , Expires , HttpOnly , Domain , Path

        public int MaxAge { get; set; }
        public string Path { get; set; }
        public bool HttpOnly { get; set; }


        // Set-Cookie: SSID=Ap4P…GTEq; Domain=foo.com; Path=/; Max-Age=2; Expires=Wed, 13 Jan 2021 22:23:01 GMT; Secure; HttpOnly
        public override string ToString()
        {
            StringBuilder cookieBuilder = new StringBuilder();
            cookieBuilder.Append($"{this.Name}={this.Value}; Path={this.Path};");
            if (MaxAge != 0)
            {
                cookieBuilder.Append($" Max-Age={this.MaxAge};");
            }

            if (this.HttpOnly)
            {
                cookieBuilder.Append(" HttpOnly;");
            }

            return cookieBuilder.ToString();
        }
    }
}
