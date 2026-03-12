using Microsoft.AspNetCore.Identity;

namespace BlogApi.Models
{
    public class User : IdentityUser
    {

        // IdentityUser already includes properties like Id, UserName, Email, Password

        public Role Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
    }
}
