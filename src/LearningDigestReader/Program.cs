using System.Xml;
using System.ServiceModel.Syndication;
using System.Runtime.InteropServices;

string url = "https://techcommunity.microsoft.com/t5/s/gxcuf89792/rss/board?board.id=AzureCompute";
using (XmlReader reader = XmlReader.Create(url))
{
    SyndicationFeed feed = SyndicationFeed.Load(reader);
    Console.WriteLine(feed.Title.Text);
    Console.WriteLine(feed.Links[0].Uri);
    Console.WriteLine(" ");
    foreach (SyndicationItem item in feed.Items)
    {
        Console.WriteLine("Title: " + item.Title.Text);
        Console.WriteLine("Link: " + item.Links[0].Uri);
        Console.WriteLine("Publish Date: " + item.PublishDate.DateTime.ToString("dd/MM/yyyy"));
        Console.WriteLine(" ");
    }
}
