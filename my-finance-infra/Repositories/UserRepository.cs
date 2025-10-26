using Microsoft.EntityFrameworkCore;
using my_finance_domain.Entities;
using my_finance_domain.Interfaces.Repositories;
using my_finance_infra.Persistence;

namespace my_finance_infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MyFinanceDbContext _context;

    public UserRepository(MyFinanceDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync() =>
        await _context.Users.AsNoTracking().ToListAsync();

    public async Task<User?> GetByIdAsync(Guid id) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}