using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSFIX = "Command";
        public string Read(string inputLine)
        {
            string[] tokens = inputLine.Split();

            string commandName = tokens[0] + COMMAND_POSFIX;

            string[] commandArgs = tokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] types = assembly.GetTypes();

            Type typeToCreate = types.FirstOrDefault(x => x.Name == commandName);

            if (typeToCreate == null)
            {
                throw new InvalidOperationException("Invalid Command Type!");
            }

            Object instance = Activator.CreateInstance(typeToCreate);

            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
