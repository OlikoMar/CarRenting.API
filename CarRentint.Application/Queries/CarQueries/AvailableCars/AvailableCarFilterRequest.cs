namespace CarRenting.Application.Queries.CarQueries.AvailableCars;

public class AvailableCarFilterRequest
{
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public string DealerName { get; set; }
    public string CarType { get; set; }
}