namespace CarRenting.Domain;

public interface IRepository<T>
{
    Task<T> FindByIdAsync(int id);
}