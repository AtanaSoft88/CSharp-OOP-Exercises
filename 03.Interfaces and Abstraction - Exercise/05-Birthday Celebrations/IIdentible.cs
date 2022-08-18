using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    interface IIdentible
    {
        public string Birthdate { get; }
        void AddBirthDate(List<string> result);
    }
}
