using CommandLine;
using CommandLine.Text;

namespace SafranCLI
{
    public class Options
    {
        [Option('f', "feed", MutuallyExclusiveSet = "0",
            HelpText = "Show feed list.")]
        public bool Feed { get; set; }


        [Option('o', "open", MutuallyExclusiveSet = "0",
            HelpText = "Open feed item. Usage: -o [number]")]
        public int Open { get; set; }

        [Option('l', "link", MutuallyExclusiveSet = "0",
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
