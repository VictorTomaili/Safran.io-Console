using System;
using System.Collections.Generic;
using SafranConsole.Console;
using SafranConsole.Console.Interface;

namespace SafranConsole.Safran.SafranCommands
{
    public class SafranRefreshCommand : IConsoleCommand
    {
        public const string command = "refresh";
        public const string description = "Safran Konu Başlıklarını Yeniler";

        public SafranRefreshCommand()
        {
            Command = command;
            Description = description;
            Action = SafranList;
        }

        private void SafranList()
        {
            Safran.io.Refresh();
            Console.Execute(SafranFeedCommand.command);
        }

        public string Command { get; set; }
        public string Description { get; set; }
        public Action Action { get; set; }
        public IEnumerable<string> Parameter { get; set; }
        public ConsoleContent Console { get; set; }
    }
}