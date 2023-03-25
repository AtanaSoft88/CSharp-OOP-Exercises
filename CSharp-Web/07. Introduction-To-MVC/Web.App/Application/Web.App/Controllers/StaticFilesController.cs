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
    class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request) // Action
        {
            return this.FileReturn("wwwroot/favicon.ico", "image/vnd.microsoft.icon");  //image/x-icon , "image/vnd.microsoft.icon"

        }
    }
}
