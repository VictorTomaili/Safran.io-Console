using System.ComponentModel;
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
            RunCommand();
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
            
            if (!CommandList.ContainsKey(ConsoleInput))
            {
                Write(string.Format("\"{0}\" Komut Bulunamadı", command));
                return;
            }
            
            CommandList[command].Action();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}