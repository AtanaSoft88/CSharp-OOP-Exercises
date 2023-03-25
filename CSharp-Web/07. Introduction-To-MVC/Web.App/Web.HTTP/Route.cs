using System;
using Web.HTTP.Enums;

namespace Web.HTTP
{
    public class Route
    {
        public Route(string path, TypeMethod method, Func<HttpRequest,HttpResponse> action)
        {
            this.Action = action;
            this.Path = path;
            this.Method = method;
        }
        public string Path { get; set; }    
        public Func<HttpRequest,HttpResponse> Action { get; set; }

        public TypeMethod Method { get; set; }      
    }
}
