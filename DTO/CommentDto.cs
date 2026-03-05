using BlogApi.Models;

namespace BlogApi.DTO
{
    public class CommentDto : BaseId
    {
        public string Text { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
