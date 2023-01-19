using CarRenting.Application.Queries.CarQueries.AvailableCars;
using CarRenting.Application.Queries.CarQueries.CarAfterRent;

namespace CarRenting.Application.Queries.CarQueries;

public interface ICarFilterQuery
{
    Task<AvailableCarFilterResponse> GetAvailableCars(AvailableCarFilterRequest request, CancellationToken token);
    Task<CarAfterRentFilterResponse> GetCarAfterRent(CarAfterRentFilterRequest request, CancellationToken token);
}