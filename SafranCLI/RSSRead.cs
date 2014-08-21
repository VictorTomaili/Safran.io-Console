using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace SafranCLI
{
    public static class RSSRead
    {
        private const string FeedUri = "http://www.safran.io/feed.rss";

        public static List<FeedItem> GetFeed()
        {
            var feedItems = new List<FeedItem>();
            using (var reader = XmlReader.Create(FeedUri))
            {
                var load = SyndicationFeed.Load(reader);
                reader.Close();

                if (load == null)
                    return feedItems;

                feedItems.AddRange(from item in load.Items
                    let link = item.Links.FirstOrDefault()
                    select new FeedItem
                    {
                        Title = item.Title.Text,
                        Description = item.Summary.Text,
                        Guid = item.Id,
                        Link = link != null ? link.Uri.ToString() : null,
                        PubDate = item.PublishDate.ToString()
                    });
            }

            return feedItems;
        }
    }
}
