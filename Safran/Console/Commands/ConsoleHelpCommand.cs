
namespace SafranConsole.Console.Commands
{
    public class ConsoleHelpCommand : ConsoleCommand
    {
        public const string command = "help";
        public const string description = "Yardım Bilgisini Görüntüler";

        public ConsoleHelpCommand()
        {
            Command = command;
            Description = description;
            Action = Help;
        }

        private void Help()
        {
            Console.Clear();
            Console.Write("----------------- HELP ------------------");
            foreach (var cmd in this.Console.CommandList)
            {
                Console.Write(string.Format("{0}\t: {1}", cmd.Key, cmd.Value.Description));
            }
            Console.Write("-----------------------------------------");
        }
    }
}