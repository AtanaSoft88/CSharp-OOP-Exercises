using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Web.HTTP
{   
    public class HttpServer : IHttpServer
    {
        List<Route> routeTable = new List<Route>();
        public HttpServer(List<Route>routeTable)
        {
            this.routeTable = routeTable;
        }            
        public async Task StartAsync(int port)
        {//We provide the connection between 2 devices ports - we open socket ( tcp connection)
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback,port); // IPAddress.Loopback - working with the local PC
            tcpListener.Start();
            while (true)
            {   //This loop we wait a Client to catch the connection with the method "AcceptTcpClient()" , and start working with this Client
                // This is a method which Blocks the rest operations ,so best way to bypass is to "await" ,so we wait to get the result from this method and pass it to the method below -> "ProcessClientAsync".
                TcpClient client = await tcpListener.AcceptTcpClientAsync();

                //Here we wont use "await" cuz we are not interested of the result of handling this client to proceed ahead with another client.Обработваме всички клиенти на куп( може да са 10_000 и повече) .Пуснали сме тредове/нишки да обработват, но не чакаме "await" да се обработва клиент по клиент с изчакване между всеки 2 клиента ,а се работят паралелно и се изсипват всички в метода.      
                ProcessClientAsync(client); 
            }
        }

        private async Task ProcessClientAsync(TcpClient client)
        {//We open stream ( we can send and receive data) and use Buffer as byte[] for preserving the data which we send/receive in chunks
         //Stream implements IDisposable,so we must make "using" to dispose with Garbage Collector automatically after the end of this piece of code.

            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    //Variant 1)) -> Niki Kostov - the way to initialize buffer for reading data from server as string

                    List<byte> data = new List<byte>();
                    int position = 0;
                    byte[] buffer = new byte[HttpConstants.bufferSize]; // chunk
                    while (true)
                    {
                        int count = await stream.ReadAsync(buffer, position, buffer.Length);
                        position += count;
                        if (count < buffer.Length)
                        {
                            var partialBuffer = new byte[count];//this byte[] has the length of the total read bytes from the previous buffer
                            Array.Copy(buffer, partialBuffer, count);
                            data.AddRange(partialBuffer);
                            break;
                        }
                        else
                        {
                            data.AddRange(buffer);
                        }
                        if (count< HttpConstants.bufferSize)
                        {
                            break;
                        }
                    }

                    //byte[] => string(text)
                    var requestAsString = Encoding.UTF8.GetString(data.ToArray());



                    //Variant 2 Ivo Kenov
                    //byte[] buffer = new byte[1024];
                    //StringBuilder requestBuilder = new StringBuilder();

                    //while (stream.DataAvailable)
                    //{
                    //    int currentBytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    //    requestBuilder.Append(Encoding.UTF8.GetString(buffer,0, currentBytesRead));
                    //    if (currentBytesRead < 1024)
                    //    {
                    //        break;
                    //    }

                    //}

                    var request = new HttpRequest(requestAsString); //or from Variant 1 -> requestAsString
                    Console.WriteLine($"Method:{request.Method}, Path: {request.Path}, Headers count:{request.Headers.Count} ->\r\n{string.Join("\r\n",request.Headers)}\r\n");
                    //Console.WriteLine($"Method:{request.Method}, Path: {request.Path},Cookie:{request.Cookies.FirstOrDefault()}, Headers count:{request.Headers.Count}");

                    HttpResponse response;
                    //Compares both strings with ignoreCase = true ,and if they are equal after string comparison - 0 is returned
                    var route = routeTable.FirstOrDefault(x=>string.Compare(x.Path, request.Path, true) == 0 && x.Method == request.Method ); 
                    if (route != null)
                    {
                        response = route.Action(request);
                    }
                    else
                    {
                        // Not Found 404
                        response = new HttpResponse("text/html", new byte[0], Enums.HttpStatusCode.NotFound);
                    }

                    response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
                    { HttpOnly = true, MaxAge = 60 * 24 * 60 * 60 });
                    response.Headers.Add(new Header("Server", "Web-Server2022 1.0"));
                    var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());
                    await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
                    await stream.WriteAsync(response.BodyResponse, 0, response.BodyResponse.Length);
                }

                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
