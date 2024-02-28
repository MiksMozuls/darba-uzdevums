using DarbaUzdevumaProjekts.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DarbaUzdevumaProjekts.Controllers
{
    public class NewsController : Controller
    {
        // Atgriež visas Ziņas kas ir datubāzē
        public async Task<ActionResult<List<NewsPiece>>> GetNews() { 
            throw new NotImplementedException(); 
        }

        // Atgriež ziņas no noteikta avota 
        public async Task<ActionResult<List<NewsPiece>>> GetNewsFromSource(string sourceName) 
        {
            throw new NotImplementedException();
        }

        // Atgriež specifisku ziņu 
        public async Task<ActionResult<NewsPiece>> GetNewsPiece(int NewsID)
        {
            throw new NotImplementedException();
        }
        

        // Scraper funkcija -------------------------------  




    }
}
