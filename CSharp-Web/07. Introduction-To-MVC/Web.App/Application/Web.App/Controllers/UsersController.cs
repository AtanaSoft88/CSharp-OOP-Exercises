using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.HTTP;
using Web.MvcFramework;

namespace Web.App.Controllers
{
    class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)  // Action
        {
            //[CallerMemberName] - this attribute in "Controller" abstract class automatically puts "Login" inside View()  =>>> Veiw("Login")
            //The method "Login" calls the method View() , so caller's name is returned by this Attribute [CallerMemberName]!
            return this.View();            
        }

        public HttpResponse Register(HttpRequest request) // Action
        {
            //[CallerMemberName]-this attribute in "Controller" abstract class automatically puts "Register" inside View()  =>>> Veiw("Register")
            ////The method "Register" calls the method View() , so caller's name is returned by this Attribute [CallerMemberName]!
            return this.View();
            
        }

        public HttpResponse StyleCss(HttpRequest request) // Action
        {
            return this.FileReturn("wwwroot/css/style.css", "text/css");
        }

        public HttpResponse DoLogin(HttpRequest request)
        {
            //todo
            //read data, check user for valid data if so logg in and redirect to Home Page
            return this.Redirect("/");
        }

    }
}
