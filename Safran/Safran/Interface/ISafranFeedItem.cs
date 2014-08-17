namespace SafranConsole.Safran.Interface
{
    public interface ISafranFeedItem
    {
        string Title { get; set; }
        string Description { get; set; }
        string PubDate { get; set; }
        string Link { get; set; }
        string Guid { get; set; }
    }
}