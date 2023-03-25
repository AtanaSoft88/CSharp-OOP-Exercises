using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Web.HTTP;
using Web.HTTP.Enums;

namespace Web.MvcFramework
{
    //We keep all of the Classes with equal functionallity and part of MVC pattern. Abstract/base class cant be instantiated
    public abstract class Controller
    {    //this.GetType().Name - won't give us anything connected with this abstract class "Controller" here because it cant be instantiated, but   will give us its child classes when called
        //Polymorphism gives us the concrete class type name ->>this.GetType().Name -> "HomeController,UsersController..etc
        //So we need only to replace the substring "Controller" with string.Empty or in our case with "/" !

        //The best magic here if this.View can get the name of the method which called this.View? - This can be done with Attribute :
        // "[CallerMemberName]" - gives the method name(Index,Login,Register...etc) who calls this method "View()" where Attribute has been put!
        public HttpResponse View([CallerMemberName] string viewPath=null)
        {   
            var layout = File.ReadAllText("Views/Layout.cshtml");

            var viewContent = File.ReadAllText("Views/" + this.GetType().Name.Replace("Controller","/")  + viewPath + ".cshtml");

            var responseHtml = layout.Replace("@RenderBody()", viewContent);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            return response;
        }

        public HttpResponse FileReturn(string filePath, string connectionType) 
        {
            var fileBytes = File.ReadAllBytes(filePath);
            var response = new HttpResponse(connectionType, fileBytes);
            return response;
        }

        public HttpResponse Redirect( string url)
        {
            var response = new HttpResponse(HttpStatusCode.Found);
            response.Headers.Add(new Header("Location", url));
            return response;
        }
    }
}
