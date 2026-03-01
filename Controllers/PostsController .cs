using Microsoft.AspNetCore.Mvc;
using BlogApi.Models;
using BlogApi.Interfaces;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllAsync();
            return Ok(posts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            await _postService.CreateAsync(post);
            return Ok(post);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest("ID mismatch");
            }
            await _postService.UpdateAsync(post);
            return Ok(post);
        }
    }
}
