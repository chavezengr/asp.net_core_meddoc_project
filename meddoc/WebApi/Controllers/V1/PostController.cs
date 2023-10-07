using Microsoft.AspNetCore.Mvc;
using WebApi.Routes;

namespace WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class PostController : Controller
    {
      
        // POST: PostController/Create
        [HttpGet]
        [Route(ApiRoutes.Posts.GetById)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok();
        }

    }
}
