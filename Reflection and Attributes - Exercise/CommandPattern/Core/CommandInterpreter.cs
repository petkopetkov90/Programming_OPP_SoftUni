using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core;

public class CommandInterpreter : ICommandInterpreter
{
    public string Read(string args)
    {
        string[] commandDetails = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string commandName = string.Concat(commandDetails[0], "Command");
        string[] commandArguments = commandDetails.Skip(1).ToArray();

        Assembly assembly = Assembly.GetEntryAssembly();
        Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName);

        if (commandType is null)
        {
            throw new InvalidOperationException("Invalid command");
        }

        ICommand command = Activator.CreateInstance(commandType) as ICommand;

        return command.Execute(commandArguments).ToString();
    }
}
