using System;
using System.Collections.Generic;

namespace SafranConsole.Console.Interface
{
    public interface IConsoleCommand
    {
        string Command { get; set; }
        string Description { get; set; }
        Action Action { get; set; }
        IEnumerable<string> Parameter { get; set; }
        ConsoleContent Console { get; set; }
    }
}