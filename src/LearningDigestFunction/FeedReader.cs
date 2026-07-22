using System.Xml;
using System.ServiceModel.Syndication;

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