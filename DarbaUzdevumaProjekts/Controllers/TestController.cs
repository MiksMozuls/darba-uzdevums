using DarbaUzdevumaProjekts.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace DarbaUzdevumaProjekts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public class Query : IRequest<Test> 
        { 
        
        }

        public class Handler : IRequestHandler<Query, Test> { 
        
        
        }
    }
}
