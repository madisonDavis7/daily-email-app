using System.Xml;
using System.ServiceModel.Syndication;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Globalization;

string url = "https://techcommunity.microsoft.com/t5/s/gxcuf89792/rss/board?board.id=AzureCompute";


using (XmlReader reader = XmlReader.Create(url))
{
    SyndicationFeed feed = SyndicationFeed.Load(reader);
    Console.WriteLine(feed.Title.Text);
    Console.WriteLine(feed.Links[0].Uri);
    Console.WriteLine(" ");

    List<Article> learningArticles = new List<Article>();
    foreach (SyndicationItem item in feed.Items)
    {
        var article = new Article
        {
            Title = item.Title.Text,
            Link = item.Links[0].Uri.ToString(),
            Date = item.PublishDate.DateTime.ToString("dd/MM/yyyy"),
        };

        learningArticles.Add(article);
    }

    foreach (Article article in learningArticles)
    {
        Console.WriteLine("Title: " + article.Title);
        Console.WriteLine("Link: " + article.Link);
        Console.WriteLine("Published Date: " + article.Date);
        Console.WriteLine(" ");
    }
}

public class Article
{
    public required string Title { get; init; }
    public required string Link { get; init; }
    public required string Date { get; init; }
}