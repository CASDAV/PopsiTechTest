using System;
using Microsoft.EntityFrameworkCore;
using Popsi.Domain.Entities;
using Popsi.Domain.Interfaces;

namespace Popsi.Infrastructure.Persistance.Repositories;

public class LabourRepository : ILabourRepository
{
    private readonly AppDbContext _appDbContext;

    public LabourRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> CreateLabour(Labour newLabour)
    {
        await _appDbContext.Labours.AddAsync(newLabour);
        await _appDbContext.SaveChangesAsync();

        return newLabour.Id;
    }

    public async Task DeleteLabour(int id)
    {
        var labour = await _appDbContext.Labours.FindAsync(id);

        if (labour != null)
        {
            _appDbContext.Labours.Remove(labour);
            await _appDbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Labour>> GetAllLabours()
    {
        return await _appDbContext.Labours.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Labour>> GetLaboursByUserId(int id)
    {
        return await _appDbContext.Labours.Where(l => l.Owner == id).AsNoTracking().ToListAsync();
    }

    public async Task UpdateLabour(Labour newLabour)
    {
        var labour = await _appDbContext.Labours.FindAsync(newLabour.Id);

        if (labour != null)
        {
            _appDbContext.Labours.Update(newLabour);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
