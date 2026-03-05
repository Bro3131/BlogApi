using BlogApi.Data;
using BlogApi.Models;
using BlogApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Persistence
{
    public class Repository<T> : IRepository<T> where T : BaseId
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext db)
        {
            _db = db;
            _table = db.Set<T>(); 
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _table.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _table.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _table.FindAsync(id);
            if (entity != null)
            {
                _table.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

    }
}
