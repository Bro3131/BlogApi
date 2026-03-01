using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task CreateAsync(Post post);
        Task DeleteAsync(int id);
        Task UpdateAsync(Post post);

    }
}
