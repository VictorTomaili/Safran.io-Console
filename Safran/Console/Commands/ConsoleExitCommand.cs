
using System;
using System.Collections.Generic;
using SafranConsole.Console.Interface;

namespace SafranConsole.Console.Commands
{
    public class ConsoleExitCommand : IConsoleCommand
    {
        public const string command = "exit";
        public const string description = "Uygulamayı Kapatır";

        public ConsoleExitCommand()
        {
            Command = command;
            Description = description;
            Action = () => Environment.Exit(0);
        }

        public string Command { get; set; }
        public string Description { get; set; }
        public Action Action { get; set; }
        public IEnumerable<string> Parameter { get; set; }
        public ConsoleContent Console { get; set; }
    }
}