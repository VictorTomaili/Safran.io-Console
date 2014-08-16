
using System;

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

        public void Focus()
        {
            Scroller.ScrollToEnd();
            InputBlock.Focus();
            InputBlock.CaretIndex = Int32.MaxValue;
        }
    }
}