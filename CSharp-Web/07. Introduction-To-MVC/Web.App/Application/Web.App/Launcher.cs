using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Web.App.Controllers;
using Web.HTTP;
using Web.MvcFramework;

namespace Web.App
{
    //Programs.cs project depends on HTTP

    //HTTP proj - contains : request, response , cookies , httpServer ( base manipulations with the http Server)

    //MVC Framework proj : it is like an Abstraction upon the HTTP - it is designed to make HttpServer function easeier
    //It solves the following problems:
    //-if we want to have dynamic Html ( it is called view) 
    //-if we want Routes not to describe 1 by 1 ,but the MVCFramework to know how to handle itself
    //-if we want to put these methods from StartUp class in another Classes(Controllers) so we don't mess up all methods in one place.
    //Controllers are the Classes which contain Actions

    //Usually the final product -> The Console App is working with MVCFramework ( provides higher Abstraction) ,which itself is working with HTTP ,so we can say "Our program starts at Console App and works directly with MVCFramework (for better Abtraction) while MVC is working with HTTP".    
    //Data/or Models folder is designed to keep : "DbContext, Migrations, Models (classes representing the Database entities)
    //Here Extention of Initial version.Here start Introducing MVC structure
    //MVC Introduction - 02h10.00 -gledai video ot tuk!!!


    public class Launcher
    {
        public static async Task Main(string[] args)
        {
            await Host.RunAsync(new StartUp(), 80);
        }
    }
}
