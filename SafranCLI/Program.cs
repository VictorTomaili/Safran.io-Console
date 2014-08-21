using System;
using CommandLine;

namespace SafranCLI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();

            if (args.Length == 0)
            {
                Console.WriteLine(options.GetUsage());
                return;
            }
            
            var feed = RSSRead.GetFeed();

            if (Parser.Default.ParseArguments(args, options))
            {
                if (options.Feed)
                    foreach (var item in feed)
                        Console.WriteLine("{0} : {1}", feed.IndexOf(item) + 1, GetTitle(item, subStrEnd: 10));

                if (options.Open > 0)
                {
                    var item = feed[options.Open - 1];
                    Console.WriteLine(GetTitle(item));
                    Console.WriteLine(new string('-', Console.BufferWidth));
                    Console.WriteLine(item.Description);

                    if (options.Link)
                        LinkFinder.Find(item.Description).ForEach(s => System.Diagnostics.Process.Start(s));
                }
            }
        }

        private static string GetTitle(FeedItem item, int subStrEnd = 1)
        {
            var maxLenght = Console.BufferWidth - subStrEnd;
            var title = string.Format("{0:g} - {1}", DateTime.Parse(item.PubDate), item.Title);
            return title.Substring(0, title.Length > maxLenght ? maxLenght : title.Length);
        }
    }
}