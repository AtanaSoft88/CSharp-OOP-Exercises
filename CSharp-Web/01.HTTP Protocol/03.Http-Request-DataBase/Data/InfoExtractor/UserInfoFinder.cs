using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Http_Request.Data.InfoExtractor
{
    public static class UserInfoFinder
    {
        public static string UserAndPasswordExtractor(string requestString)
        {
            string usernameInfo = string.Empty;
            requestString.Split("/r/n").ToList();

            int indexUsername = requestString.IndexOf("username=");
            usernameInfo = requestString.Substring(indexUsername, requestString.Length - indexUsername);
            usernameInfo = usernameInfo
                .Replace("username=", "")
                .Replace("password=", "")
                .Replace("Address=","")
                .Replace("Age=","")
                .Replace("Email=", "")
                .Replace("%40", "@")
                .Replace("&", " ");

            return usernameInfo;
        }
    }
}   // username=nas88&password=rtrtr444566&Address=Adress-Varna&Age=32&Email=djx700%40abv.bg
