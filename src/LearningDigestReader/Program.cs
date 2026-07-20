using System.Xml;
using System.ServiceModel.Syndication;

string url = "https://techcommunity.microsoft.com/t5/s/gxcuf89792/rss/board?board.id=AzureCompute";
using (XmlReader reader = XmlReader.Create(url))
{
    SyndicationFeed feed = SyndicationFeed.Load(reader);
    Console.WriteLine(feed.Title.Text);
    Console.WriteLine(feed.Links[0].Uri);
    foreach (SyndicationItem item in feed.Items)
    {
        Console.WriteLine(item.Title.Text);
        Console.WriteLine(" ");
    }
}
