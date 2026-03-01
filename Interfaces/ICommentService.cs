using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetAllAsync();
        Task CreateAsync(Comment comment);
        Task DeleteAsync(int id);
        Task UpdateAsync(Comment comment);
    }
}
