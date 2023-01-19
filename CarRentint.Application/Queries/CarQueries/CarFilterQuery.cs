using CarRenting.Application.DataModels;
using CarRenting.Application.Queries.CarQueries.AvailableCars;
using CarRenting.Application.Queries.CarQueries.CarAfterRent;
using CarRenting.Domain;
using CarRenting.Domain.Models;
using CarRenting.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarRenting.Application.Queries.CarQueries;

public class CarFilterQuery : ICarFilterQuery
{
    private readonly ICarRepository _repository;
    public CarFilterQuery(ICarRepository repository)
    {
        _repository = repository;
    }

    public async Task<AvailableCarFilterResponse> GetAvailableCars(AvailableCarFilterRequest request, CancellationToken token)
    {
        var availableCars = await _repository
            .Query()
            .Where(s => s.Dealer.ToString() == request.DealerName
                        || s.Type.ToString() == request.CarType
                        || s.AvailableFrom <= request.StartDate
                            && s.AvailableTo >= request.EndDate)
            .ToListAsync(token);

        return !availableCars.Any() ? null : new AvailableCarFilterResponse { Cars = new List<AvailableCarDto>() };
    }


    public async Task<CarAfterRentFilterResponse> GetCarAfterRent(CarAfterRentFilterRequest request, CancellationToken token)
    {
        var car = await _repository.FindByGuidAsync(request.CarId);

        return car == null ? null : new CarAfterRentFilterResponse { Car = new CarAfterRentFilterRequest { CarId = car.Id } };
    }
}