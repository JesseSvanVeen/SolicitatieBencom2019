using LinqToTwitter;
using SolicitatieBencom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SolicitatieBencom.Controllers
{
    public class TweetController : Controller
    {
        // GET: Tweet
        public async Task<ActionResult> Index()
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = "aQBh039RRPgFa5n2Sq7tCehvK",
                    ConsumerSecret = "rWLAY9WOJGBdl1Bn9tvbFVV27iZeRKOoK2pqXkJBrXYkhv4i4l",
                    OAuthToken = "1159055105699848192-yGJreGEXLHhHktPIQuHiCfaoobGfzE",
                    OAuthTokenSecret = "J0xqhBqZR1GisevDRxTxW7HrtnY1d8aecbukO7zBsOdVA"
                }

            };
            var context = new TwitterContext(auth);
            var tweets = new List<TweetViewModel>();
            var searchResponse =
                await
                (from search in context.Search
                 where search.Type == SearchType.Search &&
                       search.Query == "kaas"
                 select search)
                .SingleOrDefaultAsync();

            if (searchResponse != null && searchResponse.Statuses != null)
            {
                searchResponse.Statuses.ForEach(tweet => tweets.Add(new TweetViewModel { User = tweet.User.ScreenNameResponse, Tweet = tweet.Text }));
            }

            return View(tweets);

        }

    }
}