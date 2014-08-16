using System.Windows;
using System.Windows.Input;

namespace SafranConsole.Console
{
    public partial class SafranIo : Window
    {
        public ConsoleContent Console { get; set; }

        public SafranIo()
        {
            InitializeComponent();
            Console = new ConsoleContent(this.InputBlock, this.Scroller);
            DataContext = Console;
            Loaded += MainWindow_Loaded;
            Console.ConsoleClear += ConsoleOnConsoleClear;
            Console.Clear();
        }
        
        private void ConsoleOnConsoleClear()
        {
            Console.Write("Safran.io");
            Console.Write("Console");
            Console.Write("------------------------------------------");
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Console.Focus();
        }

        private void FocusConsole(object sender, MouseButtonEventArgs e)
        {
            Console.Focus();
        }
    }
}
