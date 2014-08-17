using SafranConsole.Console;

namespace SafranConsole.Safran.SafranCommands
{
    public class SafranRefreshCommand : ConsoleCommand
    {
        public const string command = "refresh";
        public const string description = "Safran Konu Başlıklarını Yeniler";

        public SafranRefreshCommand()
        {
            Command = command;
            Description = description;
            Action = SafranList;
        }

        private void SafranList()
        {
            Console.Clear();
            Safran.io.Refresh();
            Console.Execute(SafranGetFeedCommand.command);
        }
    }
}