using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.HTTP
{
    public interface IHttpServer
    {
        Task StartAsync(int port);
    }
}
