using CarRenting.Domain.Models;

namespace CarRenting.Domain;

public interface ICarRepository : IRepository<Car>
{
    Task<Car> FindByGuidAsync(Guid id); 
    IQueryable<Car> Query();
}