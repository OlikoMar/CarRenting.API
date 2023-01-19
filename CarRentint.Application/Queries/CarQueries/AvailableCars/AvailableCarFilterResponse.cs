using CarRenting.Application.DataModels;

namespace CarRenting.Application.Queries.CarQueries.AvailableCars;

public class AvailableCarFilterResponse
{
    public IEnumerable<AvailableCarDto> Cars { get; set; }
}