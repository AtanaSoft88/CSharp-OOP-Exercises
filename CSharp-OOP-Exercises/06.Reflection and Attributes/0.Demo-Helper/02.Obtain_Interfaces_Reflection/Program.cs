using System;
using System.Collections.Generic;
using System.Reflection;

namespace Obtain_Interfaces_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car(80000,"WV GOLF", 2005, 105);
            Random rnd = new Random();
            Console.WriteLine($"Car initial km :{car.Kilometers}");
            while (!car.isOldCar && car.Kilometers < 100_000)
            {
                int drivenKm = rnd.Next(2000, 10_000);
                car.Drive(drivenKm);
                
                Console.WriteLine($"Car current driven km:{drivenKm}");
                Console.WriteLine($"Car Total driven km:{car.Kilometers}");
                Console.WriteLine();
            }
            //===============================================================
            //How to get all interfaces of a class and with nested foreach we cant get access to all methods

            Type[] interfaces = car.GetType().GetInterfaces();
            Console.WriteLine("All interfaces : ->>");
            foreach (var interf in interfaces)
            {
                Console.WriteLine(interf.Name);                
                
            }
            Console.WriteLine();
            Console.WriteLine("All methods inside interfaces : ->>");
            foreach (var interf in interfaces)
            {                
                foreach (var meth in interf.GetMethods())
                {
                    Console.WriteLine(meth.Name);
                }

            }

            // How to get properties of a class using instance of that class
            string input = "Obtain_Interfaces_Reflection.Car";
            Type type = typeof(Car);
            object inst = Activator.CreateInstance(type,"Pesho");
            Console.WriteLine(type.Name);
            foreach (var property in inst.GetType().GetProperties())
            {
                Console.WriteLine(property.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Enum class properties:");
            Console.WriteLine();

            Type typeEnum = typeof(Enum);
            foreach (var property in type.GetType().GetProperties())
            {
                Console.WriteLine(property.Name);
            }

            Console.WriteLine("PropertyInfo class - How to get properties using this class :");
            PropertyInfo[] props = typeof(Car).GetProperties();
            foreach (var property in props)
            {
                Console.WriteLine(property.Name);
            }

            // How to get public fields of a class using instance of that class
            FieldInfo[] fields = typeof(Car).GetFields();

            foreach (var field in fields)
            {
                Console.WriteLine(field.Name);
            }

            // How to get Private/Non-Public etc fields of a class using Binding Flags

            Type typeBind = typeof(Car);
            FieldInfo[] typeBindingFields = typeBind.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            object objInst = Activator.CreateInstance(typeBind, "Koko");
            foreach (var item in typeBindingFields)
            {
                if (item.FieldType == typeof(System.String))
                {
                    item.SetValue(objInst, "Nasko");
                    Console.WriteLine(item.GetValue(objInst));
                    
                }
                
            }

            // How to set a private field value .
            Type typeSetValue = typeof(Car);
            FieldInfo[] fieldsSet = typeSetValue.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            object instance = Activator.CreateInstance(typeSetValue, "Pesho");
            foreach (var fi in fieldsSet)
            {
                if (fi.FieldType == typeof(System.String))
                {
                    fi.SetValue(instance,"Nasko");
                    Console.WriteLine(fi.GetValue(instance));
                }
            }

            //How to get constructors info
            Type typeCtor = typeof(Car);
            ConstructorInfo[] ctors = typeCtor.GetConstructors(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Static);
            int count = 0;
            foreach (var cons in ctors)
            {
                Console.WriteLine($"This is Constructor No:{++count}");
                foreach (var param in cons.GetParameters())
                {
                    Console.WriteLine($"Parameter type is:|{param.ParameterType}| , and Parameter name is:/{param.Name}/");
                   
                }
                
            }
            // How to get field info through constructor type
            Type typeInvoke = typeof(Car);
            ConstructorInfo ctorsInvoke = typeInvoke.GetConstructor(new Type[] {typeof(string)});

            FieldInfo[] fieldsInv = typeInvoke.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

            object instanceInv = ctorsInvoke.Invoke(new object[] {"Misho"});

            foreach (var fiInv in fieldsInv)
            {
                if (fiInv.FieldType == typeof(System.String))
                {
                    //fiInv.SetValue(instanceInv, "Krakra");
                    Console.WriteLine(fiInv.Name);
                    Console.WriteLine(fiInv.GetValue(instanceInv));
                }
                
            }
        }
    }
}
