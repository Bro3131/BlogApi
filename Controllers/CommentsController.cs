using Microsoft.AspNetCore.Mvc;
using BlogApi.Models;
using BlogApi.DTO;
using Mapster;
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
            var comment = await _commentService.GetAllAsync();
            return Ok(comment);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CommentDto dto)
        {
            
            var comment = dto.Adapt<Comment>();
            await _commentService.CreateAsync(comment);
            return Ok(comment);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut("update-comment")]
        public async Task<IActionResult> Update(CommentDto dto)
        {
            var comment = dto.Adapt<Comment>();
            await _commentService.UpdateAsync(comment);
            return Ok(comment);

        }


    }
}
