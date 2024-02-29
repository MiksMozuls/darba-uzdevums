using DarbaUzdevumaProjekts.Domain;
using DarbaUzdevumaProjekts.Persistance;
using HtmlAgilityPack;

namespace DarbaUzdevumaProjekts.Application
{
    public class Scraper
    {
        public async static Task<List<NewsPiece>> TvnetScraper(DataContext _context)
        {
            var url = "https://www.tvnet.lv/";

            var web = new HtmlWeb();
            var doc = web.Load(url);

            var articles = doc.DocumentNode.SelectNodes("//article/a");

            List<NewsPiece> pieces = new List<NewsPiece>();

            foreach (var article in articles)
            {
                var articleUrl = article.Attributes["href"].Value;

                if (articleUrl.Contains("tvnet"))
                {
                    var articleweb = new HtmlWeb();
                    var articledoc = web.Load(articleUrl);





                    var titleNode = articledoc.DocumentNode.SelectNodes("//h1[@itemprop='headline name']");
                    string title = "";
                    try
                    {
                        title = titleNode.First().InnerText;


                        Console.WriteLine(HtmlEntity.DeEntitize(title));
                    }
                    catch
                    {
                        continue;

                    }


                    var textNodes = articledoc.DocumentNode.SelectNodes("//p");
                    string fulltext = "";

                    foreach (var node in textNodes)
                    {
                        fulltext += node.InnerText;

                    }



                    pieces.Add(new NewsPiece
                    {
                        NewsID = new Guid(),
                        Title = title,
                        Text = fulltext,
                        Link = articleUrl,
                        NewsSourceID = _context.NewsSource.Where(m => m.SourceName == "TVNET").First().SourceID,
                        NewsSource = _context.NewsSource.Where(m => m.SourceName == "TVNET").First()
                    }); ;
                }




            }
            return pieces;
        }
        public async static Task<List<NewsPiece>> LsmScraper(DataContext _context)
        {
            var url = "https://www.lsm.lv";

            var web = new HtmlWeb();
            var doc = web.Load(url);

            var articles = doc.DocumentNode.SelectNodes("//figcaption/a");

            List<NewsPiece> pieces = new List<NewsPiece>();
            foreach (var article in articles)
            {
                var articleUrl = url + article.Attributes["href"].Value;

                if (articleUrl.Contains("replay.lsm") || _context.NewsPiece.Where(n => n.Link == articleUrl).Any())
                {
                    continue;
                }



                var articleweb = new HtmlWeb();
                var articledoc = web.Load(articleUrl);

                var titleNode = articledoc.DocumentNode.SelectNodes("//h2[@class='article-lead']").First();
                var textNode = articledoc.DocumentNode.SelectNodes("//div[@class='article__body']").First();
                pieces.Add(new NewsPiece
                {
                    NewsID = new Guid(),
                    Title = titleNode.InnerText,
                    Text = textNode.InnerText,
                    Link = articleUrl,
                    NewsSource = _context.NewsSource.Where(m => m.SourceName == "TVNET").First()
                }); 


            }
            return pieces;


        }
    }
}
