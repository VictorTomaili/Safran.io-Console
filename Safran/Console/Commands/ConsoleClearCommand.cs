
namespace SafranConsole.Console.Commands
{
    public class ConsoleClearCommand : ConsoleCommand
    {
        public ConsoleClearCommand()
        {
            this.Command = "clear";
            this.Description = "Ekranı Temizler";
            this.Action = () => Console.Clear();
        }
    }
}