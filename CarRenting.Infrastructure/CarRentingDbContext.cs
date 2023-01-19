using CarRenting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRenting.Infrastructure;

public class CarRentingDbContext : DbContext
{
    public CarRentingDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Dealer> Dealers { get; set; } = default!;
    public DbSet<Car> Cars { get; set; } = default!;
    public DbSet<Customer> Customers { get; set; } = default!;
    public DbSet<CarRent> CarRents { get; set; } = default!;
}