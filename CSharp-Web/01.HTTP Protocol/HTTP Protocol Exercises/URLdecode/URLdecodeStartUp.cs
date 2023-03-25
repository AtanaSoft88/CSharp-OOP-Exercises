using System;
using System.Net;

namespace URLdecode
{
    class URLdecodeStartUp
    {
        static void Main()
        {
            string[] inputURL =
            {
                   "http://www.google.bg/search?q=C%23",
                   "https://mysite.com/show?n%40m3= p3%24h0",
                   "http://url-decoder.com/i%23de%25?id=23"
            };

            foreach (var url in inputURL)
            {
                string outputURL = WebUtility.UrlDecode(url);
                Console.WriteLine(outputURL);
            }

        }
    }
}
