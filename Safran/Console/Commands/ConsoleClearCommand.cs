
namespace SafranConsole.Console.Commands
{
    public class ConsoleClearCommand : ConsoleCommand
    {
        public const string command = "clear";
        public const string description = "Ekranı Temizler";

        public ConsoleClearCommand()
        {
            Command = command;
            Description = description;
            Action = () => Console.Clear();
        }
    }
}