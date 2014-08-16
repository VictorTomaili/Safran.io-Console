
using System;

namespace SafranConsole.Console
{
    public class ConsoleCommand
    {
        public string Command { get; set; }
        public string Description { get; set; }
        public Action Action { get; set; }
        public ConsoleContent Console { get; set; }
    }
}