using Domain.Aggregates.PostAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PostController : Controller
    {

        // POST: PostController/Create
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            
            return Ok();
        }

    }
}
