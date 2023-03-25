namespace Web.HTTP
{
    public class Cookie
      //Example for Cookie Value
    { // _fbp=fb.1.1655713825883.2040494365; _gcl_au=1.1.1868421405.1655713826; cookiesAccepted=1; externalCookiesAccepted=1; 

        public Cookie(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public Cookie(string cookieAsString)
        {
            var cookieParts = cookieAsString.Split(new char[] {'='},2);
            this.Name = cookieParts[0];
            this.Value = cookieParts[1];
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}={this.Value}";
        }
    }
}