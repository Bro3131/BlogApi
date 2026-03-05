using BlogApi.Interfaces;
using BlogApi.Data;   
using Microsoft.EntityFrameworkCore;
using BlogApi.Models;

namespace BlogApi.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _repository;

        public CommentService(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task CreateAsync(Comment comment)
        {
            await _repository.CreateAsync(comment);
        }

        public async Task UpdateAsync(Comment comment)
        {
            await _repository.UpdateAsync(comment);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
