
using System;
using System.Collections.Generic;
using SafranConsole.Console.Interface;

namespace SafranConsole.Console.Commands
{
    public class ConsoleClearCommand : IConsoleCommand
    {
        public const string command = "clear";
        public const string description = "Ekranı Temizler";

        public ConsoleClearCommand()
        {
            Command = command;
            Description = description;
            Action = () => Console.Clear();
        }

        public string Command { get; set; }
        public string Description { get; set; }
        public Action Action { get; set; }
        public IEnumerable<string> Parameter { get; set; }
        public ConsoleContent Console { get; set; }
    }
}