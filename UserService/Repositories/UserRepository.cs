using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserRepository
{
    private readonly UserDbContext _context;
    public UserRepository(UserDbContext context) => _context = context;

    public async Task<List<User>> GetUsersAsync() => await _context.Users.ToListAsync();
    public async Task<User> GetUserByIdAsync(int id) => await _context.Users.FindAsync(id);
    public async Task AddUserAsync(User user) { _context.Users.Add(user); await _context.SaveChangesAsync(); }
}
