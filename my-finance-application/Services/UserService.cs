using my_finance_domain.Entities;
using my_finance_domain.Interfaces.Repositories;
using my_finance_domain.Interfaces.Services;

namespace my_finance_application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User> CreateAsync(User user)
    {
        await _userRepository.AddAsync(user);
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        var existing = await _userRepository.GetByIdAsync(user.Id);
        if (existing is null)
            throw new KeyNotFoundException("User not found.");

        existing.Name = user.Name;
        existing.Email = user.Email;

        await _userRepository.UpdateAsync(existing);
        return existing;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await _userRepository.GetByIdAsync(id);
        if (existing is null)
            return false;

        await _userRepository.DeleteAsync(existing);
        return true;
    }
}