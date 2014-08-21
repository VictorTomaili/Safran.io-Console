
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SafranCLI
{
    public static class LinkFinder
    {
        public const string UrlRegex =
            @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)";
        public static List<string> Find(string text)
        {
            return (from Match match in Regex.Matches(text, UrlRegex, RegexOptions.Singleline)
                    select match.Groups[1].Value.Trim()).ToList();
        }
    }
}
 