using System;
using System.Linq;
using SafranConsole.Console;

namespace SafranConsole.Safran.SafranCommands
{
    public class SafranGetFeedCommand : ConsoleCommand
    {
        public const string command = "getfeed";
        public const string description = "Safran Konu Başlıklarını Getirir";

        public SafranGetFeedCommand()
        {
            Command = command;
            Description = description;
            Action = SafranList;
        }

        private void SafranList()
        {
            Console.Clear();

            var feedList = Safran.io.GetFeedList().ToList();

            foreach (var item in feedList)
            {
                Console.Write(string.Format("{0}\t: [{1:g}] - {2}", 
                    feedList.IndexOf(item) + 1,
                    DateTime.Parse(item.PubDate),
                    item.Title));
            }
        }
    }
}