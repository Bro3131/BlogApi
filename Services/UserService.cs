using BlogApi.Interfaces;
using BlogApi.Models;
using BlogApi.Data;
using Microsoft.EntityFrameworkCore;


namespace BlogApi.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(User user)
        {
            await _repository.CreateAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _repository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
