using BlogApi.Models;

namespace BlogApi.DTO
{
    public class PostDto : BaseId
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
