using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.ServiceModel.Syndication;

namespace LearningDigestFunction;

public class LearnDigest
{
    private readonly ILogger<LearnDigest> _logger;

    public LearnDigest(ILogger<LearnDigest> logger)
    {
        _logger = logger;
    }

    [Function("LearnDigest")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        string rssUrl = "https://techcommunity.microsoft.com/t5/s/gxcuf89792/rss/board?board.id=AzureCompute";

        using (XmlReader reader = XmlReader.Create(rssUrl))
        {
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            _logger.LogInformation("--------" + feed.Title.Text + "--------");
            _logger.LogInformation("{Uri}", feed.Links[0].Uri);
            _logger.LogInformation(" ");

            // Get the articles from the feed and take the first three
            var learningArticles = FeedReader.GetArticles(feed);
            var firstNumberOfArticles = learningArticles.Take(3);

            foreach (Article article in firstNumberOfArticles)
            {
                _logger.LogInformation("Title: {Title}", article.Title);
                _logger.LogInformation("Link: {Link}", article.Link);
                _logger.LogInformation("Date: {Date}", article.Date);
                _logger.LogInformation(" ");
            }

            return new OkObjectResult(firstNumberOfArticles);

        }


        //_logger.LogInformation("C# HTTP trigger function processed a request.");
    }
}
