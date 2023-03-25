using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Test_Http_Request.Data;
using Test_Http_Request.Data.InfoExtractor;


namespace Test_Http_Request
{
    public class StartUp
    {

        static async Task Main(string[] args)
        {
            var contextHttp = new HttpContext();
            //await contextHttp.Database.EnsureDeletedAsync();
            await contextHttp.Database.EnsureCreatedAsync();

            Console.OutputEncoding = Encoding.UTF8;
            const string NewLine = "\r\n";

            TcpListener listener = new TcpListener(IPAddress.Loopback, 80);
            listener.Start();
            bool isRegistration = false;
            bool isLogin = false;
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                DataBaseInfo dataBaseInfo = new DataBaseInfo();
                using (var stream = client.GetStream())
                {
                    byte[] buffer = new byte[4096];
                    int length = await stream.ReadAsync(buffer, 0, buffer.Length);

                    string requestString = Encoding.UTF8.GetString(buffer, 0, length);
                    string user = string.Empty;
                    string pass = string.Empty;
                    
                    var html = string.Empty;                    
                    
                    if (requestString.Contains("username=") && requestString.Contains("/reg")) // if Post request when using Registration form "htmlRegister"
                    {
                        string resultUserAndPass = UserInfoFinder.UserAndPasswordExtractor(requestString);
                        string username = resultUserAndPass.Split(' ')[0];
                        string password = resultUserAndPass.Split(' ')[1];
                        string address = resultUserAndPass.Split(' ')[2];
                        string age = resultUserAndPass.Split(' ')[3];
                        string email = resultUserAndPass.Split(' ')[4];

                        user = username;
                        pass = password;
                        
                        await dataBaseInfo.AddUsersToDataBase(contextHttp,username,password,address,age,email);
                        isRegistration = false;
                    }
                    else if (isLogin && requestString.Contains("username=") && requestString.Contains("/log"))
                    {
                        string resultUserAndPass = UserInfoFinder.UserAndPasswordExtractor(requestString);
                        string username = resultUserAndPass.Split(' ')[0];
                        string password = resultUserAndPass.Split(' ')[1];
                        user = username;
                        pass = password;
                        isLogin = false;
                    }
                    
                    Console.WriteLine(requestString);
                    Console.WriteLine(new String('*', 60));
                    // if i use Button - can be redirected to another website, if i use submit , i cant be redirected
                    //string htmlLogin = $"<h1>Hello from My Server 2022. Time:{DateTime.Now}</h1>" +
                    //    "<form action=/info method=post>" +
                    //    "<input name=\"username\" placeholder=\"Username\" id=\"usr\"/> <br/> \r\n" +
                    //    "<input name=\"password\" placeholder=\"Password\" id=\"pass\" /><br/> \r\n" +
                    //    "<input type=\"button\" value=\"Login\" onclick=\"javascript:validate()\" /></form>" + "<script type=\"text/javascript\">\r\n    function validate() {\r\n        if (document.getElementById(\"usr\").value == \"123\"\r\n            && document.getElementById(\"pass\").value == \"123\") {\r\n            alert(\"Access Granted!\");\r\n            window.location.href = \"https://google.com\"\r\n\r\n        }\r\n        else {\r\n            alert(\"Validation failed\");\r\n            location.href = \"#\";\r\n        }\r\n    }\r\n\r\n</script>" +
                    //    "<h3>This page is made by Nasko</h3>" +
                    //    "<h3><strong>Contacts</strong></h3>" +
                    //    "<h4>Gsm: 0894656060</h4>" +
                    //    "<h4>Address: Varna,Bulgaria</h4>" +
                    //    $"<h4>ID : {new Random().Next(10000, 30000)}</h4>";

                    var userNames = dataBaseInfo.UserNamesDBExtract(contextHttp);
                    var userPasswords = dataBaseInfo.PasswordsDBExtract(contextHttp);

                    if (!userNames.Contains(user) || !userPasswords.Contains(pass))
                    {
                        user = "";
                        pass = "";
                    }
                    string testUs = string.Join(" ", userNames);
                    
                    string testPass = string.Join(" ", userPasswords);

                    string htmlLogin = $"<h1>Hello from My Server 2022. Time:{DateTime.Now}</h1>" +
                        "<form action=/log method = post>" +
                        "<input name=\"username\" placeholder=\"Username\" id=\"usr1\"/> <br/> \r\n" +
                        "<input name=\"password\" placeholder=\"Password\" id=\"pass1\" /><br/> \r\n" +
                        "<input type=\"button\" value=\"Login\" onclick=\"javascript:Validation()\" /></form>" +
                        $"<script type=\"text/javascript\">\r\n            const user = \"{testUs}\";\r\n            const pass = \"{testPass}\";\r\n            \r\n    </script>" +
                        "<script type=\"text/javascript\">\r\n            \r\n        function Validation(){         \r\n            if (user.indexOf(document.getElementById(\"usr1\").value)!==-1 && document.getElementById(\"usr1\").value !==\"\" &&\r\n         pass.indexOf(document.getElementById(\"pass1\").value)!==-1 && document.getElementById(\"pass1\").value !==\"\") {\r\n          alert(\"Access Granted!\");\r\n          location.href = \"http://google.com\";\r\n        } else {\r\n          alert(\"Validation failed\");\r\n          location.href = \"#\";\r\n        }\r\n            \r\n        }\r\n        \r\n        </script>" +
                        "<h3>This page is made by Nasko</h3>" +
                        "<h3><strong>Contacts</strong></h3>" +
                        "<h4>Gsm: 0894656060</h4>" +
                        "<h4>Address: Varna,Bulgaria</h4>" +
                        $"<h4>ID : {new Random().Next(10000, 30000)}</h4>";

                   string htmlRegister = "<h1>Registration Form</h1>\r\n    <h3>You can get registrated after filling the following form:</h3>\r\n    <form action=\"reg\" method =post>\r\n        <input type=\"text\" name=\"username\" placeholder=\"Username\" id=\"usr1\"><br></br>\r\n        <input type=\"password\" name=\"password\" placeholder=\"Password\" minlength=\"6\" maxlength=\"32\" id=\"pass\"><br></br>\r\n        <input type=\"text\" name=\"Address\" placeholder=\"Address\" id=\"addr\"><br></br>\r\n        <input type=\"number\" name=\"Age\" placeholder=\"Age\" min=\"1\" max=\"101\" id=\"age\"> <br></br>\r\n        <input type=\"email\" name=\"Email\" placeholder=\"Email\" id=\"email\"><br></br>\r\n        <input type=\"submit\" value=\"Enter your info here!\" onclick=\"javascript:ValidationAttributes()\">\r\n    </form>\r\n    <script>\r\n        function ValidationAttributes(){\r\n            if (document.getElementById(\"usr1\").value.length < 3) {\r\n                alert(\"Username must be at least 3 symbols long!\")\r\n                return false;\r\n            }\r\n        }\r\n    </script>";

                    if (requestString.Contains("reg"))
                    {
                        isRegistration = true;
                        html = htmlRegister;
                    }
                    else if (requestString.Contains("GET /log"))
                    {
                        isLogin = true;
                        html = htmlLogin;
                    }

                    string response = "HTTP/1.1 200 OK" + NewLine +
                        "Server: NaskoServer 2022" + NewLine +
                        "Content-Type: text/html; charset=\"UTF-8\"" + NewLine +
                        "Content-Lenght: "  + html.Length + NewLine +
                        "Set-Cookie: sid = 8807gsahsa7788909ssga"  + NewLine + //set-biscuit
                        NewLine +
                        html + NewLine;

                   

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    await stream.WriteAsync(responseBytes);

                }
            }
        }
    }
}
