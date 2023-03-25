using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.HTTP.Enums
{
    public enum HttpStatusCode
    {
        OK = 200,
        MovedPermanently = 301,
        Found = 302,
        TemporaryRedirect = 307,
        NotFound = 404,
        BadRequest = 400,
        ServerError = 500,


    }
}
