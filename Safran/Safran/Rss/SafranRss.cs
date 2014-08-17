using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using SafranConsole.Safran.Interface;

namespace SafranConsole.Safran.Rss
{
    public class SafranRss : ISafranDataProvider
    {
        private const string FeedUri = "http://www.safran.io/feed.rss";
        private List<ISafranFeedItem> FeedItems { get; set; } 

        public SafranRss()
        {
            FeedItems = new List<ISafranFeedItem>();
            Refresh();
        }

        public void Refresh()
        {
            FeedItems.Clear();
            var reader = XmlReader.Create(FeedUri);
            var load = SyndicationFeed.Load(reader);
            reader.Close();
            
            if (load != null)
            {
                foreach (var item in load.Items)
                {
                    var link = item.Links.FirstOrDefault();
                    FeedItems.Add(new SafranFeedItem
                    {
                        Title = item.Title.Text,
                        Description = item.Summary.Text,
                        Guid = item.Id,
                        Link = link != null ? link.Uri.ToString() : null,
                        PubDate = item.PublishDate.ToString()
                    });
                }
            }
        }

        public List<ISafranFeedItem> GetFeedList()
        {
            if(FeedItems.Count == 0)
                Refresh();
            return FeedItems;
        }
    }
}