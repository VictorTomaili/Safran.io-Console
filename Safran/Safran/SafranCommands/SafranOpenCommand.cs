using System;
using System.Data;
using System.Linq;
using SafranConsole.Console;

namespace SafranConsole.Safran.SafranCommands
{
    public class SafranOpenCommand : ConsoleCommand
    {
        public const string command = "open";
        public const string description = "Safran Konu Başlığını açar Orn: open 1";

        public SafranOpenCommand()
        {
            Command = command;
            Description = description;
            Action = SafranList;
        }

        private void SafranList()
        {
            var feedList = Safran.io.GetFeedList().ToList();
            int idx;
            if (Parameter == null || !Parameter.Any() || (!Int32.TryParse(Parameter.FirstOrDefault(), out idx)))
                throw new InvalidExpressionException("Parametre Geçersiz.");

            if((idx -1) > feedList.Count)
                throw new IndexOutOfRangeException("Başlık Bulunamadı.");

            Console.Clear();
            Console.Execute(SafranGetFeedCommand.command);
            System.Diagnostics.Process.Start(feedList[idx - 1].Link);
        }
    }
}