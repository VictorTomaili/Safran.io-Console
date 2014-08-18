using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SafranConsole.Console;
using SafranConsole.Console.Interface;
using SafranConsole.Safran.Interface;

namespace SafranConsole.Safran.SafranCommands
{
    public class SafranOpenCommand : IConsoleCommand
    {
        public const string command = "open";

        public const string description = "Safran konu başlığını açar. Örn: " + command +
                                          " [0-9] | " + command +
                                          " [0-9] link";
        
        public SafranOpenCommand()
        {
            Command = command;
            Description = description;
            Action = SafranList;
        }

        private void SafranList()
        {
            if(Parameter == null || !Parameter.Any())
                throw new InvalidExpressionException("Parametre Geçersiz.");

            var feedList = Safran.io.GetFeedList().ToList();
            
            int idx;
            if (Int32.TryParse(Parameter.ElementAt(0), out idx))
            {
                idx--;
                if ((idx) > feedList.Count)
                    throw new IndexOutOfRangeException("Başlık Bulunamadı.");

                if (Parameter.Count() == 1)
                {
                    WriteFeedItem(feedList[idx]);
                    return;
                }
            }

            if(Parameter.ElementAt(1) == "link")
            {
                foreach (var url in LinkFinder.Find(feedList[idx].Description))
                {
                    System.Diagnostics.Process.Start(url);
                }
            }
        }

        private void WriteFeedItem(ISafranFeedItem item)
        {
            Console.NewLine();
            Console.Write("##################");
            Console.NewLine();
            Console.Write("------------------");
            Console.Write(item.Title);
            Console.Write("------------------");
            Console.Write(item.Description.Trim());
            Console.NewLine();
            Console.Write("##################");
            Console.NewLine();
        }

        public string Command { get; set; }
        public string Description { get; set; }
        public Action Action { get; set; }
        public IEnumerable<string> Parameter { get; set; }
        public ConsoleContent Console { get; set; }
    }
}