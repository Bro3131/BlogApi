using BlogApi.DTO;
using BlogApi.Interfaces;
using BlogApi.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var comment = await _commentService.GetAllAsync();
            return Ok(comment);
        }


        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Create(CommentDto dto)
        {
            
            var comment = dto.Adapt<Comment>();
            await _commentService.CreateAsync(comment);
            return Ok(comment);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut("update-comment")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(CommentDto dto)
        {
            var comment = dto.Adapt<Comment>();
            await _commentService.UpdateAsync(comment);
            return Ok(comment);
        }
    }
}
