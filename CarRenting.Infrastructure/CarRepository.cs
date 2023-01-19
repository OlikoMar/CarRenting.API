using CarRenting.Domain;
using CarRenting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRenting.Infrastructure;

public class CarRepository : Repository<Car>, ICarRepository
{
    private readonly CarRentingDbContext _context;
    public CarRepository(CarRentingDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Car> FindByGuidAsync(Guid id)
    {
        return await _context.Set<Car>().FirstOrDefaultAsync(c => c.Id == id);
    }

    public IQueryable<Car> Query()
    {
        return _context.Set<Car>();
    }
}