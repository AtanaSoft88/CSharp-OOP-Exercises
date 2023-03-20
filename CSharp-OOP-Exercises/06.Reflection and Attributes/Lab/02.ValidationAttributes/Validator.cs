using System;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propInfos = obj.GetType().GetProperties().Where(x=>x.GetCustomAttributes(typeof(MyValidationAttribute)).Any()).ToArray();

            foreach (var prop in propInfos)
            {
                object value = prop.GetValue(obj);
                MyValidationAttribute attribute = prop.GetCustomAttribute<MyValidationAttribute>();
                bool isValid = attribute.IsValid(value);
                if (!isValid)
                {
                    return false;
                }
            }
            return true;
        }
    }
}