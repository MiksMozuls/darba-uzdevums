using DarbaUzdevumaProjekts.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

// Tests lai pārbaudītu Api darbību 
namespace DarbaUzdevumaProjekts.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("")]
        public async Task<ActionResult<Test>> TestAction() {
            
            return new Test (); 
            
        }

    }
}
