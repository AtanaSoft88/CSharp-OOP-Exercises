using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.HTTP;

namespace Web.MvcFramework
{
    public static class Host
    {
        public static async Task RunAsync(IMvcApplication application, int port=80) 
        {
            List<Route> routeTable = new List<Route>();
            application.ConfigureServices();
            application.Configure(routeTable); // give the route table by refference, so this method "Configure" fills up the initial List<Route>
            IHttpServer server = new HttpServer(routeTable);
            
            await server.StartAsync(port);
        }
    }
}
