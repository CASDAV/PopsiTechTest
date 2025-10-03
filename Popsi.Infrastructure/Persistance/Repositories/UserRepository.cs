using System;
using Microsoft.EntityFrameworkCore;
using Popsi.Domain.Entities;
using Popsi.Domain.Interfaces;

namespace Popsi.Infrastructure.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> CreateUser(User newUser)
    {
        await _appDbContext.AddAsync(newUser);
        await _appDbContext.SaveChangesAsync();

        return newUser.Id;
    }

    public async Task DeleteUser(int id)
    {
        var user = await _appDbContext.Users.FindAsync(id);
        if (user != null)
        {
            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<User?>> GetAllUsers()
    {
        return await _appDbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _appDbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task UpdateUser(User user)
    {
        var usr = await _appDbContext.Users.FindAsync(user.Id);
        if (usr != null)
        {
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
