using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace GenericArrayCreator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.OutputEncoding = Encoding.UTF8;
            
            bool isType6 = false;
            bool isType5 = false;
            Console.WriteLine("За кое ТОТО желаете да генерираме числа за вас? Натисни \"6\" за ТОТО 6х49 или \"5\" за ТОТО 5х35 ");
            

            int inputTotoType = int.Parse(Console.ReadLine());
            if (inputTotoType == 6)
            {
                isType6 = true;
                Console.WriteLine("Генериране на възможна печеливша комбинация от цифри за ТОТО 6х49");
            }
            else if (inputTotoType == 5)
            {
                isType5 = true;
                Console.WriteLine("Генериране на възможна печеливша комбинация от цифри за ТОТО 5х35");

            }
                        

            int[] stringCreate = ArrayCreator.Create(inputTotoType, 0);

            int randomNumber = 0;
            for (int i = 0; i < stringCreate.Length; i++)
            {
                if (isType6)
                {
                    randomNumber = rnd.Next(1, 50);
                }
                else if (isType5)
                {
                    randomNumber = rnd.Next(1, 36);
                }
                if (!stringCreate.Any(x=>x.Equals(randomNumber)))
                {
                    stringCreate[i] = randomNumber;
                }
                else
                {
                    i--;
                }
                
            }
            Console.WriteLine("Натисни /Enter/");
            int count = 0;
            string defaultEntry = "Натисни /Enter/";
            string overTryEntry = "Майтап си правя ,сега натисни онова дългото копче на клавиатурата! :))))";
            bool isCountHigh = false;
            while (true)
            {
                ConsoleKeyInfo name = Console.ReadKey();

                if (name.Key != ConsoleKey.Spacebar)
                {
                    if (count>2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(overTryEntry);
                        isCountHigh = true;
                        count = 0;
                        continue;
                    }
                }
                if (name.Key == ConsoleKey.Spacebar)
                {
                    break;
                }
                else
                {
                    if (isCountHigh)
                    {
                        Console.WriteLine();
                        Console.WriteLine(overTryEntry);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(defaultEntry);
                    }
                }
                count++;
            }
            Console.WriteLine();
            Console.WriteLine("$ $ $ $ $ $ $ $");
            Console.WriteLine(string.Join(",", stringCreate));
            Console.WriteLine("$ $ $ $ $ $ $ $");



            

        }
    }
}
