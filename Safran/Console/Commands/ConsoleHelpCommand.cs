
namespace SafranConsole.Console.Commands
{
    public class ConsoleHelpCommand : ConsoleCommand
    {
        public ConsoleHelpCommand()
        {
            this.Command = "help";
            this.Description = "Yardım Bilgisini Görüntüler";
            this.Action = Help;
        }

        private void Help()
        {
            foreach (var command in this.Console.CommandList)
            {
                Console.Write(string.Format("{0}\t: {1}", command.Key, command.Value.Description));
            }
        }
    }
}