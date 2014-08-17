
using System.Collections.Generic;
using SafranConsole.Safran.Interface;

namespace SafranConsole.Safran
{
    public partial class Safran
    {
        public ISafranDataProvider SafranDataProvider { get; set; }

        public Safran(ISafranDataProvider safranRss)
        {
            SafranDataProvider = safranRss;
        }

        public IEnumerable<ISafranFeedItem> GetFeedList()
        {
            return SafranDataProvider.GetFeedList();
        }

        public void Refresh()
        {
            SafranDataProvider.Refresh();
        }
    }
}