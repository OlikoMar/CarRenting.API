namespace CarRenting.Domain.Models;

public class CarRent : BaseEntity
{
    public Car Car { get; set; }
    public Customer Customer { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public decimal TotalPrice { get; set; }
}