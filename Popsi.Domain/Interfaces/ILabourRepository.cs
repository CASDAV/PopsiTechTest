using System;
using Popsi.Domain.Entities;

namespace Popsi.Domain.Interfaces;

public interface ILabourRepository
{
    public Task<IEnumerable<Labour>> GetAllLabours();
    public Task<IEnumerable<Labour>> GetLaboursByUserId(int id);
    public Task<int> CreateLabour(Labour newLabour);
    public Task UpdateLabour(Labour newLabour);
    public Task DeleteLabour(int id); 
}
