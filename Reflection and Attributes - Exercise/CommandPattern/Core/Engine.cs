using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core;

public class Engine : IEngine
{
    private ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            string command = Console.ReadLine();

            try
            {
                Console.WriteLine(commandInterpreter.Read(command));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
