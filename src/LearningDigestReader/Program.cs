using System.Xml;
using System.ServiceModel.Syndication;


string url = "https://techcommunity.microsoft.com/t5/s/gxcuf89792/rss/board?board.id=AzureCompute";
// Create an XmlReader to read the RSS feed from the URL
using (XmlReader reader = XmlReader.Create(url))
{
    SyndicationFeed feed = SyndicationFeed.Load(reader);
    Console.WriteLine("--------" + feed.Title.Text + "--------");
    Console.WriteLine(feed.Links[0].Uri);
    Console.WriteLine(" ");

    // Get the articles from the feed and take the first three
    var learningArticles = FeedReader.GetArticles(feed);
    var firstNumberOfArticles = learningArticles.Take(3);

    Console.WriteLine("-------------------------------------------");
    foreach (Article article in firstNumberOfArticles)
    {
        Console.WriteLine("Title: " + article.Title);
        Console.WriteLine("Link: " + article.Link);
        Console.WriteLine("Date: " + article.Date);
        Console.WriteLine(" ");
    }

}

// Define the Article class to represent an article from the RSS feed
public class Article
{
    public required string Title { get; init; }
    public required string Link { get; init; }
    public required string Date { get; init; }

}

public class FeedReader
{
    // Method to extract articles from the SyndicationFeed
    public static List<Article> GetArticles(SyndicationFeed feed)
    {
        // Create a list to hold the articles
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
        return learningArticles;
    }
}

