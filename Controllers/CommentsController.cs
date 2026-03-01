using Microsoft.AspNetCore.Mvc;
using BlogApi.Models;
using BlogApi.Interfaces;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentControllers : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentControllers(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _commentService.GetAllAsync();
            return Ok(posts);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            await _commentService.CreateAsync(comment);
            return Ok(comment);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest("ID mismatch");
            }
            await _commentService.UpdateAsync(comment);
            return Ok(comment);

        }


    }
}
