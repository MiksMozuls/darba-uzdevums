using DarbaUzdevumaProjekts.Domain;
using DarbaUzdevumaProjekts.Persistance;
using HtmlAgilityPack;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DarbaUzdevumaProjekts.Application
{
    public class Scraper
    {

        public async static Task<Unit> Scrape(DataContext _context){
            var LSMArticles = await Scraper.LsmScraper(_context);
            var TvnetArticles = await Scraper.TvnetScraper(_context);
            return Unit.Value; 
        }
        public async static Task<Unit> TvnetScraper(DataContext _context)
        {
            var url = "https://www.tvnet.lv/";

            var web = new HtmlWeb();
            var doc = web.Load(url);

            var articles = doc.DocumentNode.SelectNodes("//article/a");

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
                    var SourceId = _context.NewsSource.Where(m => m.SourceName == "TVNET").First().SourceID;
                    var Source = _context.NewsSource.Where(m => m.SourceName == "TVNET").First();

                    foreach (var node in textNodes)
                    {
                        fulltext += node.InnerText;

                    }

                    _context.Add(new NewsPiece
                    {
                        NewsID = new Guid(),
                        Title = HtmlAgilityPack.HtmlEntity.DeEntitize(title),
                        Text = HtmlAgilityPack.HtmlEntity.DeEntitize(fulltext),
                        Link = articleUrl,
                        NewsSourceID = SourceId,
                        NewsSource = Source
                    }); 

                    await _context.SaveChangesAsync();
                }




            }
            return Unit.Value;
        }
        public async static Task<Unit> LsmScraper(DataContext _context)
        {
            var url = "https://www.lsm.lv";

            var web = new HtmlWeb();
            var doc = web.Load(url);

            var articles = doc.DocumentNode.SelectNodes("//figcaption/a");

            foreach (var article in articles)
            {
                var articleUrl = url + article.Attributes["href"].Value;

                var Source = _context.NewsSource.Where(m => m.SourceName == "LSM").First();
                if (articleUrl.Contains("replay.lsm") || _context.NewsPiece.Where(n => n.Link == articleUrl).Any())
                {
                    continue;
                }



                var articleweb = new HtmlWeb();
                var articledoc = web.Load(articleUrl);

                var titleNode = articledoc.DocumentNode.SelectNodes("//h2[@class='article-lead']").First();
                var textNode = articledoc.DocumentNode.SelectNodes("//div[@class='article__body']").First();
                _context.NewsPiece.Add(new NewsPiece
                {
                    NewsID = new Guid(),
                    Title = HtmlAgilityPack.HtmlEntity.DeEntitize(titleNode.InnerText),
                    Text = HtmlAgilityPack.HtmlEntity.DeEntitize(textNode.InnerText),
                    Link = articleUrl,
                    NewsSource = Source
                });
                
                await _context.SaveChangesAsync();


            }
            return Unit.Value;


        }
    }
}
