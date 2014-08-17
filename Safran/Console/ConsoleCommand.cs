
using System;
using System.Collections.Generic;

namespace SafranConsole.Console
{
    public class ConsoleCommand
    {
        public string Command { get; set; }
        public string Description { get; set; }
        public Action Action { get; set; }
        public IEnumerable<string> Parameter { get; set; }
        public ConsoleContent Console { get; set; }
    }
}