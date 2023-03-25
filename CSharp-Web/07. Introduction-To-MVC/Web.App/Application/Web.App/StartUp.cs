using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Web.App.Controllers;
using Web.HTTP;
using Web.HTTP.Enums;
using Web.MvcFramework;

namespace Web.App
{
    public class StartUp : IMvcApplication
    {
        public void ConfigureServices()
        {
            //TODO  ASP .NET CORE
        }
        // Start app and open browser : http://localhost:80
        public void Configure(List<Route> routeTable)
        {
            routeTable.Add(new Route("/", TypeMethod.GET, new HomeController().Index)); //HomePage -> Action             

            routeTable.Add(new Route("/favicon.ico", TypeMethod.GET, new StaticFilesController().Favicon)); //Favicon -> Action  

            routeTable.Add(new Route("/About", TypeMethod.GET, new HomeController().About));  //About -> Action 

            routeTable.Add(new Route("/users/Login", TypeMethod.GET, new UsersController().Login)); //Login -> Action 

            routeTable.Add(new Route("/users/Login", TypeMethod.POST, new UsersController().DoLogin)); //Redirect -> Action 

            routeTable.Add(new Route("/users/Register", TypeMethod.GET, new UsersController().Register)); //Register -> Action             

            routeTable.Add(new Route("/css/style.css", TypeMethod.GET, new UsersController().StyleCss)); //Register -> Action 

            //If we want to open the process Microsoft-Edge with code and our localhost:
            //Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", "http:/localhost/");
        }

       
    }
}