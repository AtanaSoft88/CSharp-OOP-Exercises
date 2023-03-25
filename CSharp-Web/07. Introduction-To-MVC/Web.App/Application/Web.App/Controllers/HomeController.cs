using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.HTTP;
using Web.MvcFramework;

namespace Web.App.Controllers
{
    class HomeController : Controller // Default ASP MVC way to say that is a Controller for any other things without connection with the first
    {                                  //Very often the "HomePage" is named and we can see it as : "Index" 
                                       //HomePage / Index - this is the entry point for the User. When we write in browser "localhost" 
        public HttpResponse Index(HttpRequest request) // Action - this is the place where the User goes when he opens the initial web page
        {
            //[CallerMemberName] - this attribute in "Controller" abstract class automatically puts "Index" inside View()  =>>> Veiw("Index")
            //The method "Index" calls the method View() , so caller's name is returned by this Attribute [CallerMemberName]!
            return this.View();
        }

        public HttpResponse About(HttpRequest request) // Action
        {
            return this.View();
        }        
       
    }
}
