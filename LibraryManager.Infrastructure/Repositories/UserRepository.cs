using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Repositories; 
public class UserRepository(AppDbContext context) : IUserRepository {

    private readonly AppDbContext _context = context;

    public async Task Add(User user) {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, User user) {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id) {
        var user = await _context.Users.FindAsync(id);
        if (user != null) {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<User?> GetById(int id) {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAll() {
        return await _context.Users
            .AsNoTracking()
            .ToListAsync();
    }

}
