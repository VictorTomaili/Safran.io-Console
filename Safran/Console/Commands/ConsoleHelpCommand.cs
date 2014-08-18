
using System;
using System.Collections.Generic;
using SafranConsole.Console.Interface;

namespace SafranConsole.Console.Commands
{
    public class ConsoleHelpCommand : IConsoleCommand
    {
        public const string command = "help";
        public const string description = "Yardım Bilgisini Görüntüler";

        public ConsoleHelpCommand()
        {
            Command = command;
            Description = description;
            Action = Help;
        }

        private void Help()
        {
            Console.Write("----------------- HELP ------------------");
            foreach (var cmd in this.Console.CommandList)
            {
                Console.Write(string.Format("{0}\t: {1}", cmd.Key, cmd.Value.Description));
            }
            Console.Write("-----------------------------------------");
        }

        public string Command { get; set; }
        public string Description { get; set; }
        public Action Action { get; set; }
        public IEnumerable<string> Parameter { get; set; }
        public ConsoleContent Console { get; set; }
    }
}