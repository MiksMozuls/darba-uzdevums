using DarbaUzdevumaProjekts.Application;
using DarbaUzdevumaProjekts.Domain;
using DarbaUzdevumaProjekts.Persistance;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DarbaUzdevumaProjekts.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly DataContext _context;
        public NewsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("scrape")]
        public async Task<ActionResult<NewsPiece>> ScrapeNews()
        {

            await Scraper.Scrape(_context);
            return Ok(); 
        }

        [HttpGet("GetNews")]
        // Atgriež visas Ziņas kas ir datubāzē
        public async Task<ActionResult<List<NewsPiece>>> GetNews() {
            return Ok(_context.NewsPiece);
        }
        [HttpGet("Sources")]
        // Atgriež visas Ziņas kas ir datubāzē
        public async Task<ActionResult<List<NewsSource>>> GetSources()
        {
            return Ok(_context.NewsSource);
        }

        // Atgriež ziņas no noteikta avota 
        [HttpGet("GetNewsFromSource/{sourceId}")]
        public async Task<ActionResult<List<NewsPiece>>> GetNewsFromSource(Guid sourceId) 
        {
            return Ok(_context.NewsPiece.Where(n => n.NewsSourceID == sourceId));
        }
        [HttpGet("GetNewsPiece/{newsID}")]
        // Atgriež specifisku ziņu 
        public async Task<ActionResult<NewsPiece>> GetNewsPiece(Guid newsID)
        {
            return Ok(_context.NewsPiece.Where(n => n.NewsID == newsID).First());
        }


     




    }
}
