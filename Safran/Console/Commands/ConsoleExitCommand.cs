
using System;

namespace SafranConsole.Console.Commands
{
    public class ConsoleExitCommand : ConsoleCommand
    {
        public ConsoleExitCommand()
        {
            this.Command = "exit";
            this.Description = "Uygulamayı Kapatır";
            this.Action = () => Environment.Exit(0);
        }
    }
}