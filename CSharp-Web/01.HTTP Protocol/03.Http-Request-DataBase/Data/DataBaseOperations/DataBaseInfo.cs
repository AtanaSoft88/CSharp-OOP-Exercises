using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Test_Http_Request.Data.Models;

namespace Test_Http_Request.Data
{
    public class DataBaseInfo
    {
        public async Task AddUsersToDataBase(HttpContext contextHttp, string username, string password, string address, string age, string email)
        {
            var passwordsInDataBase = UserNamesDBExtract(contextHttp);
            var usersInDataBase = PasswordsDBExtract(contextHttp);
            
            if (!usersInDataBase.Contains(username) && !passwordsInDataBase.Contains(password))
            {
                contextHttp.Users.Add(new User
                {
                    Username = username,
                    Password = password,
                    Address = address,
                    Age = int.Parse(age),
                    Email = email,

                });

                await contextHttp.SaveChangesAsync();
            }
        }

        public List<string> UserNamesDBExtract(HttpContext contextHttp)
        {
            List<string> usersInDataBase = contextHttp.Users.Select(x => x.Username).ToList();
            return usersInDataBase;
        }
        public List<string> PasswordsDBExtract(HttpContext contextHttp)
        {
            List<string> passwordsInDataBase = contextHttp.Users.Select(x => x.Password).ToList();
            return passwordsInDataBase;
        }
    }
}
