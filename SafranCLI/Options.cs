using CommandLine;
using CommandLine.Text;

namespace SafranCLI
{
    public class Options
    {
        [Option('f', "feed",
            HelpText = "Show feed list.")]
        public bool Feed { get; set; }


        [Option('o', "open",
            HelpText = "Open feed item. Usage: -o [number]")]
        public int Open { get; set; }

        [Option('l', "link",
            HelpText = "Open link in feed description. Usage -l [number]")]
        public int Link { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
