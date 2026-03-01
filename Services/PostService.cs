using BlogApi.Interfaces;
using BlogApi.Models;
using BlogApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Services
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _db;

        public PostService(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Post post)
        {
            _db.Posts.Add(post);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Post post)
        {
            _db.Posts.Update(post);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Find the entity by its key (id). Use FirstOrDefaultAsync to avoid exceptions if not found.
            var post = await _db.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if (post == null)
            {
                return;
            }

            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _db.Posts.ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            // Use predicate overload of FirstAsync to locate by Id.
            return await _db.Posts.FirstAsync(p => p.Id == id);
        }
    }
}
