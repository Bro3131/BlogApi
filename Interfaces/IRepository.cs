using Microsoft.AspNetCore.Mvc.RazorPages;
using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface IRepository<T> where T : BaseId
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
