using CarRenting.Domain;
using CarRenting.Domain.Models;

namespace CarRenting.Infrastructure;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly CarRentingDbContext _context;

    public Repository(CarRentingDbContext context)
    {
        _context = context;
    }
    public async Task<T> FindByIdAsync(int id)
    {
        return await _context.FindAsync<T>(id);
    }
}