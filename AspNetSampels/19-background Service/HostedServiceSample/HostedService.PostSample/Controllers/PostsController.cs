using HostedService.PostSample.Infrastrucrures;
using HostedService.PostSample.Sesrvices;
using Microsoft.AspNetCore.Mvc;

namespace HostedService.PostSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;
        private readonly PostCache _postCache;

        public PostsController(PostService postService, PostCache postCache)
        {
            _postService = postService;
            _postCache = postCache;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok( _postCache.Get());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _postService.GetById(id));
        }
    }
}
