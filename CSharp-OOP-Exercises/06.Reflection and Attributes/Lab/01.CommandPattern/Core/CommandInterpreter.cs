using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args) // HelloCommand Nasko
        {
            string[] input = args.Split();
            string commandName = input[0];
            string[] value = input.Skip(1).ToArray();
            
            // Assembly.GetCallingAssembly() - this gives info about all the project , using reflection
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName + "Command");

            if (type == null)
            {
                throw new InvalidOperationException("Missing command");

            }

            Type commandInterfaceSearch = type.GetInterface("ICommand");
            if (commandInterfaceSearch == null)
            {
                throw new InvalidOperationException("Not a command");
            }
            // make instance now

            var command = Activator.CreateInstance(type) as ICommand;

            //If we want to solve this problem without Reflection use below/
            //if (commandName == "HelloCommand")
            //{
            //    command = new HelloCommand();
            //    command.Execute(value);
            //}
            //else if (commandName == "ExitCommand")
            //{
            //    command = new ExitCommand();

            //}
            //else if (commandName == "BeepCommand")
            //{
            //    command = new BeepCommand();

            //}
            string result = command.Execute(value);
            return result;
        }
    }
}
