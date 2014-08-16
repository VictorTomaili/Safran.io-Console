using System.Linq;
using SafranConsole.Console;

namespace SafranConsole.Safran.SafranCommands
{
    public class SafranListCommand : ConsoleCommand
    {
        public SafranListCommand()
        {
            Command = "header list";
            Description = "Safran Konu Başlıklarını Getirir";
            Action = SafranList;
        }

        private void SafranList()
        {
            var safranNews = SafranIo.GetHeaderList().ToList();

            foreach (var safranNew in safranNews)
            {
                Console.Write(string.Format("{0} : {1}", safranNews.IndexOf(safranNew) + 1, safranNew));
            }
        }
    }
}