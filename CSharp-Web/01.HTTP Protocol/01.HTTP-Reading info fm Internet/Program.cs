using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo_HTTP
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //How to read information from server
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string url = "https://www.abv.bg/";
            HttpClient client = new HttpClient();
            string getResponseHtml = await client.GetStringAsync(url);            
            Console.WriteLine(getResponseHtml);

            var response = await client.GetAsync(url);
            Console.WriteLine($"Status code : [ {response.StatusCode} ]");
            Console.WriteLine(String.Join("\r\n",response.Headers.Select(x=>x.Key + ":" + x.Value.First())));
            
            
        }
    }
}
