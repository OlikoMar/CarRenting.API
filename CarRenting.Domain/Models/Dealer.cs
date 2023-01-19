namespace CarRenting.Domain.Models;

public class Dealer : BaseEntity
{
    public string Name { get; set; }
    public IEnumerable<Car> Cars { get; set; }
}