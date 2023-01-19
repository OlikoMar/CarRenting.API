namespace CarRenting.Domain.Models;

public class Car : BaseEntity
{
    public string Model { get; set; }
    public string Color { get; set; }
    public int ReleaseDate { get; set; }
    public DateTimeOffset AvailableFrom { get; set; }
    public DateTimeOffset AvailableTo { get; set; }
    public decimal PricePerDay { get; set; }
    public CarType Type { get; set; }
    public Dealer Dealer { get; set; }
}