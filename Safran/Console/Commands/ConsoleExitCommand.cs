
using System;

namespace SafranConsole.Console.Commands
{
    public class ConsoleExitCommand : ConsoleCommand
    {
        public const string command = "exit";
        public const string description = "Uygulamayı Kapatır";

        public ConsoleExitCommand()
        {
            Command = command;
            Description = description;
            Action = () => Environment.Exit(0);
        }
    }
}