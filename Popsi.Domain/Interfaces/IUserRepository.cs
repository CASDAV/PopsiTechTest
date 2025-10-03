using System;
using Popsi.Domain.Entities;

namespace Popsi.Domain.Interfaces;

public interface IUserRepository
{
    public Task<IEnumerable<User?>> GetAllUsers();
    public Task<User?> GetUserById(int id);
    public Task<int> CreateUser(User newUser);
    public Task UpdateUser(User user);
    public Task DeleteUser(int id);
}


