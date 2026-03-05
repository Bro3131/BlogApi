using BlogApi.Models;

namespace BlogApi.DTO
{
    public class UserDto : BaseId
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
