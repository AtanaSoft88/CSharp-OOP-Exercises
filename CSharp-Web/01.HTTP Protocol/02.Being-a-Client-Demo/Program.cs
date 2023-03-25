using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _02.Being_a_Client_Demo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //We are the server , client is the Browser now
            // Just call : http://localhost:8000/ in browser after program start .
            //On calling the webbrowser put 127.0.0.1 - for local PC , we can choose the port ( in my case 80)
            Console.OutputEncoding = Encoding.UTF8;
            const string NewLine = "\r\n";

            //We can create tcp port and operating system gives all what passes through this port - eg port 80
            //With this code below we transfer my Laptop to a server
            TcpListener tcpListener = new TcpListener(
                IPAddress.Loopback, 8000); // loopback - lockal IP address , 127.0.0.1 , local host ,this means my laptop is a server program
            tcpListener.Start();

            Dictionary<string, int> SessionsDictStorage = new Dictionary<string, int>();
            // We make endless loop , in linux called "daemon" , also "service"
            while (true) // while we have request from client - handle it !
            {
                var tcpClient = tcpListener.AcceptTcpClient(); // until client is connected to me or enters info ,then this method is blocked
                using (var stream = tcpClient.GetStream())
                {
                    //Request to the Server
                    //-------------------------------------------------------------------------------
                    byte[] buffer = new byte[1000000];
                    var lenght = stream.Read(buffer, 0, buffer.Length);

                    string requestString = Encoding.UTF8.GetString(buffer, 0, lenght);
                    Console.WriteLine(requestString);

                    //Session creation - simulating with Dictionary of key=string name , value= count of the sessions
                    //------------------------------------------------------------------------------------------------
                    
                    var sid = Guid.NewGuid().ToString(); //The session id is this by default 
                    var match = Regex.Match(requestString,@"sid=[^\n]*\r\n"); //Starts with "sid=" , has something that is NOT "\r\n" -many of it , and ends with a \r\n
                    if (match.Success) // if it matches the pattern into the requestString, that means we have a Cookie which has sent us the session id (sid)
                    {
                        sid = match.Value.Substring(4); // we get the sid without the first 4 letters ( to take only the value)
                        Console.WriteLine($"Matched Session ID (sid) = {sid}");
                    }
                    //Here we record all sessions as key -name of session , value the count of occurance of same session
                    if (!SessionsDictStorage.ContainsKey(sid))
                    {
                        SessionsDictStorage.Add(sid,0);
                    }
                    SessionsDictStorage[sid]++;

                    //------------------------------------------------------------------------------------------------
                    
                    //Logic for Biscuits - confition to be add or not to the responce Headers
                    //When we dont have that Cookie , server returns it , when we already have that Cookie , server doesn't return it. with the following logic:
                    bool sessionSet = false;
                    if (requestString.Contains("sid="))
                    {
                        sessionSet = true;  
                    }
                    //--------------------------------------------------------------------------------               




                    //Responce from the Server
                    //-----------------------------------------------------------------------------------

                    //Type of html responce
                    string un = string.Empty;
                    string htmlNaskoServer = $"<h1>Hello from NaskoServer:{DateTime.Now} for the {SessionsDictStorage[sid]} time</h1>" +
                        "<form action=/submition method=post>" +
                        $"<input name=\"username\" placeholder=\"Username\" id=\"txt1\" />\r\n" +
                        "<input name=\"password\" placeholder=\"Password\" id=\"txt2\"/>\r\n" +
                        "<input type=submit /></form>";


                    string htmlLogin = "<form action =/login>\r\n    <input type=\"text\" placeholder=\"Username\" id=\"text1\" /><br />\r\n    <input type=\"password\" placeholder=\"Password\" id=\"text2\" /><br />\r\n    <input type=\"button\" value=\"Login\"  onclick=\"javascript:validate()\" />\r\n</form>\r\n<script type=\"text/javascript\">\r\nfunction validate()\r\n{\r\n    if(   document.getElementById(\"text1\").value == \"nasko\"\r\n       && document.getElementById(\"text2\").value == \"8807\" )\r\n    {\r\n        alert( \"validation succeeded\" );        \r\n        window.location.href = \"https://google.com\"; // window.location.href -> gives to load specific web page\r\n        \r\n    }\r\n    else\r\n    {\r\n        alert( \"validation failed\" );\r\n        location.href=\"fail.html\";\r\n    }\r\n}\r\n</script>";

                    string htmlContacts = "<h1>Best Website with Contacts</h1>" +
                         "<form action=\"contacts\"><input name=\"firstname\"/> <input name=\"lastname\"/>" + "<input type=\"button\" value=\"submit me!\">" +
                         "<h3>Email Address : djx700@abv.bg</h3>\r\n <h3>GSM : +359/894/65/14/00</h3>\r\n <h3>Phone : 46/35/47</h3>\r\n <h3>Working Time : 0800AM - 1730 PM</h3>\r\n <h3>Website: bestwebsite.com</h3>" +
                         "<a href=\"https://google.com\"><input type=\"button\" value=\"Redirect me to Google!\"></a>" + "</form>";
                    //Type of html responce




                    //If we want to be redirected to another website uncomment below and comment after it

                    //string response = "HTTP/1.1 307 Redirect" + NewLine +
                    //    "Server: NaskoServer 2022" + NewLine +
                    //     "Location: https://www.google.com" + NewLine +
                    //    "Content-Type: text/html; charset=utf-8" + NewLine +
                    //    //"Content-Disposition: attachment; filename=nasko.txt" + NewLine +
                    //    "Content-Lenght: " + htmlLogin.Length + NewLine +
                    //    NewLine +
                    //    htmlLogin + NewLine;

                    string currentHtml = string.Empty;

                    if (requestString.Contains("/login"))
                    {
                        currentHtml = htmlLogin;
                    }
                    else if (requestString.Contains("/contacts"))
                    {
                        currentHtml = htmlContacts;
                    }
                    else
                    {
                        currentHtml = htmlNaskoServer;
                    }

                    string response = "HTTP/1.1 200 OK" + NewLine +
                        "Server: NaskoServer 2022" + NewLine +
                        //Content-Type can be: text/html ( returns html) ; text/plain ( for just txt); image/png (for image visualization); application/xml ( returns xml) 
                        "Content-Type: text/html; charset=utf-8" + NewLine +
                        //"Content-Disposition" -makes the browser not to visualize the content,but write it to a file if we uncomment below
                        //"Content-Disposition: attachment; filename=nasko.txt" + NewLine +
                        "Content-Lenght: " + currentHtml.Length + NewLine +
                        (!sessionSet ? ($"Set-Cookie: sid = {sid}; Max-Age="+ (3 * 60) + NewLine) :String.Empty) +
                        NewLine +
                        currentHtml + NewLine;
                    
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);


                    //----------------------------------------------------------------------------------------------
                    Console.WriteLine(new string('=', 70));

                }


            }

        }

    }
}
