using SafranConsole.Safran.Interface;

namespace SafranConsole.Safran.Rss
{
    public class SafranFeedItem : ISafranFeedItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PubDate { get; set; }
        public string Link { get; set; }
        public string Guid { get; set; }
    }
}