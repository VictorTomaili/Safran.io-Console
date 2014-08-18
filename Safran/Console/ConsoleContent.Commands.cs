
using System;
using System.Linq;
using SafranConsole.Console.Commands;

namespace SafranConsole.Console
{
    public partial class ConsoleContent
    {
        public void Clear()
        {
            this.ConsoleOutput.Clear();
            OnConsoleClear();
        }

        public void Write(string text)
        {
            ConsoleOutput.Add(text);
        }

        public void Execute(string text)
        {
            ConsoleInput = text;
            RunCommand();
        }

        public void NewLine()
        {
            ConsoleOutput.Add("");
        }

        public void Focus()
        {
            Scroller.ScrollToEnd();
            InputBlock.Focus();
            InputBlock.CaretIndex = Int32.MaxValue;
        }

        public void ShowHelp()
        {
            var helpCommand = CommandList.ToList().FirstOrDefault(s => s.Key == ConsoleHelpCommand.command);
            if (helpCommand.Value != null)
                helpCommand.Value.Action();
        }
    }
}