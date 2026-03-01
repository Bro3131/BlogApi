using BlogApi.Interfaces;
using BlogApi.Data;   
using Microsoft.EntityFrameworkCore;
using BlogApi.Models;

namespace BlogApi.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _db;

        public CommentService(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Comment comment)
        {
            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await _db.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment != null)
            {
                _db.Comments.Remove(comment);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _db.Comments.ToListAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            _db.Comments.Update(comment);
            await _db.SaveChangesAsync();
        }
    }
}
