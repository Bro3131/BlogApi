using BlogApi.DTO;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _config;


    public AuthService(UserManager<User> userManager, ITokenService tokenService, IConfiguration config)
    {
        _userManager = userManager;
        _tokenService = tokenService;
       _config = config;
    }


    public async Task<TokenModel> LoginAsync(AuthDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.Username);

        if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
            throw new UnauthorizedAccessException("user not found");

        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(double.Parse(_config["JwtSettings:RefreshTokenExpirationDays"]));
        await _userManager.UpdateAsync(user);
        return new TokenModel
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
    public async Task<TokenModel> RefreshAsync(string refreshToken)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.RefreshToken == refreshToken);
        if (user == null)
            throw new UnauthorizedAccessException("invalid refresh token");
        if (user.RefreshTokenExpiry <= DateTime.UtcNow)
            throw new UnauthorizedAccessException("refresh token expired");

        var newAccessToken = _tokenService.GenerateAccessToken(user);
        var newRefreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(double.Parse(_config["JwtSettings:RefreshTokenExpirationDays"]));
        await _userManager.UpdateAsync(user);
        return new TokenModel
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        };
    }
}