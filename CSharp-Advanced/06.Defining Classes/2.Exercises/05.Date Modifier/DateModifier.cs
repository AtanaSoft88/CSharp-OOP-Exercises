using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public static int CalcolateDifference(string firstDate, string secondDate)
        {
            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);
            //Вариант 1
            //TimeSpan timeSpan = first - second;     // начин да получим разликата между датите
            //int resultDiff = Math.Abs((int)timeSpan.TotalDays); // "TimeSpan" има пропъртито ".TotalDays"

            //Вариант 2
            int resultDiff = (int)(second - first).TotalDays;

            return resultDiff;       
        
        }

    } // когато не е статичен метода трябва при повикване от StartUp програмата да го инстанцираме "DateModifier dateModifier = new DateModifier();"
    //Така пазим в инстанцираната променлива "dateModifier" и започваме да викаме метода на много места при нужда.
    // Но ние ще ползваме само на 1 място и няма нужда от инстанция и за това правим метода тук статичен (знаейки ,че няма да го викаме многократно)и викаме метода ПРЕЗ класа в StartUp!
}
