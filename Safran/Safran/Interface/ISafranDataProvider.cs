using System.Collections.Generic;

namespace SafranConsole.Safran.Interface
{
    public interface ISafranDataProvider
    {
        List<ISafranFeedItem> GetFeedList();
        void Refresh();
    }
}