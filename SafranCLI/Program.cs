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

            if (new Parser(s =>
            {
                s.MutuallyExclusive = true;
                s.HelpWriter = Console.Error;
            }).ParseArguments(args, options))
            {
                if (options.Feed)
                {
                    Console.WriteLine(Environment.NewLine);
                    foreach (var item in feed)
                    {
                        Console.WriteLine("{0} : {1}", feed.IndexOf(item) + 1, GetTitle(item, subStrEnd: 10));
                    }
                }
                if (options.Open > 0)
                {
                    var item = feed[options.Open - 1];
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine(GetTitle(item));
                    Console.WriteLine(new string('-', Console.BufferWidth));
                    Console.WriteLine(item.Description);
                }

                if (options.Link > 0)
                {
                    var item = feed[options.Link - 1];
                    LinkFinder.Find(item.Description).ForEach(s => System.Diagnostics.Process.Start(s));
                }
                Console.WriteLine(Environment.NewLine);
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