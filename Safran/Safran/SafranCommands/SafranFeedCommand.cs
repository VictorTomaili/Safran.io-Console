using System;
using System.Collections.Generic;
using System.Linq;
using SafranConsole.Console;
using SafranConsole.Console.Interface;

namespace SafranConsole.Safran.SafranCommands
{
    public class SafranFeedCommand : IConsoleCommand
    {
        public const string command = "feed";
        public const string description = "Safran Konu Başlıklarını Getirir";

        public SafranFeedCommand()
        {
            Command = command;
            Description = description;
            Action = SafranList;
        }

        private void SafranList()
        {
            var feedList = Safran.io.GetFeedList().ToList();

            foreach (var item in feedList)
            {
                Console.Write(string.Format("{0}\t: [{1:g}] - {2}", 
                    feedList.IndexOf(item) + 1,
                    DateTime.Parse(item.PubDate),
                    item.Title));
            }
        }

        public string Command { get; set; }
        public string Description { get; set; }
        public Action Action { get; set; }
        public IEnumerable<string> Parameter { get; set; }
        public ConsoleContent Console { get; set; }
    }
}