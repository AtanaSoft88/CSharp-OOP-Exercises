using System;
using System.Reflection;

public class StartUp
{
    static void Main(string[] args)
    {
        Dummy dummy = new Dummy(100, 500);
        int ss = 0;
        try
        {
            dummy.TakeAttack(70);
            ss = dummy.GiveExperience();
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }
        Console.WriteLine(ss);
    }
}
