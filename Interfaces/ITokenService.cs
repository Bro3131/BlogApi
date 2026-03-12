using BlogApi.Models;

namespace BlogApi.Interfaces
 
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
    }
}
