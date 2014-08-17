
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Input;

namespace SafranConsole.Console
{
    public partial class ConsoleContent
    {
        void InputBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;
            
            ConsoleInput = InputBlock.Text;
#if !DEBUG
            try
            {
#endif
                RunCommand();
#if !DEBUG
            }
            catch (Exception ex)
            {
                Write(ex.Message);
            }
#endif

            ConsoleInput = String.Empty;
            InputBlock.Focus();
            Scroller.ScrollToBottom();
        }

        public delegate void ConsoleClearDelegate();
        public event ConsoleClearDelegate ConsoleClear;
        protected virtual void OnConsoleClear()
        {
            if (ConsoleClear != null)
                ConsoleClear();
        }

        public delegate void ConsoleCommandReceivedDelegate(string command);
        public event ConsoleCommandReceivedDelegate ConsoleCommandReceived;
        protected virtual void OnCommandReceived(string command)
        {
            if (ConsoleCommandReceived != null)
                ConsoleCommandReceived(command);

            var commandParts = command.Split(' ').ToList();
            var cmd = commandParts[0];
            commandParts.Remove(commandParts[0]);

            if (!CommandList.ContainsKey(cmd))
                throw new InvalidExpressionException(string.Format("\"{0}\" Komut Bulunamadı", command));

            CommandList[cmd].Parameter = commandParts;
            CommandList[cmd].Action();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}