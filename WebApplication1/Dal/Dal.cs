using Microsoft.Extensions.Caching.Memory;
using System.ServiceModel.Syndication;
using System.Xml;
using WebApplication1.Models;

namespace WebApplication1.Dal
{
    public class Dal : IDal
    {
        private readonly IMemoryCache _memoryCache;
        public Dal(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<ListModel> GetNewsList()
        {
            string cacheKey = "newsList";

            if (_memoryCache.TryGetValue(cacheKey, out List<NewsModel> cachedNewsList))
            {
                return new ListModel { list = cachedNewsList };
            }


            ListModel listModel = new ListModel
            {
                list = new List<NewsModel>()
            };

            string rssFeedUrl = "http://news.google.com/news?pz=1&cf=all&ned=en_il&hl=en&output=rss";

            using (HttpClient client = new HttpClient())
            {
                string rssFeed = await client.GetStringAsync(rssFeedUrl);
                var feed = SyndicationFeed.Load(XmlReader.Create(new StringReader(rssFeed)));

                foreach (var item in feed.Items)
                {
                    var newsModel = new NewsModel
                    {
                        title = item.Title.Text,
                        body = item.Summary.Text,
                        link = item.Links.FirstOrDefault()?.Uri.ToString()
                    };
                    listModel.list.Add(newsModel);
                }
                var expirationTime = DateTimeOffset.Now.AddMinutes(15.0);
                _memoryCache.Set("list", listModel.list, expirationTime);

                return listModel;
            }

        }
        public NewsModel TryGetCachedNewsList(string title)
        {
            var cacheData = _memoryCache.Get<List<NewsModel>>("list");
            if (cacheData != null)
            {
                foreach (var item in cacheData)
                {
                    if (item.title.Equals(title))
                    {
                        return item;
                    }
                }
            }
            return null;
        }
      
    }

}
