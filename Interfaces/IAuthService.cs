using BlogApi.DTO;
using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface IAuthService
    {
        Task<TokenModel> LoginAsync(AuthDto dto);
        Task<TokenModel> RefreshAsync(string refreshToken);
    }
}
