
using PartStore.Application.Interfaces.Repositories;
using PartStore.Domain.Entities;


namespace PartStore.Infrastructure.Implementations.Repositories;

public class PartRepository : GeneralRepository<Part>, IPartRepository
{
    public PartRepository()
    {
        _entities.Add(new Part { Id = 1, Description = "Wire", Price = 5.99m, Quantity = 5 });
        _entities.Add(new Part { Id = 2, Description = "Fluid", Price = 4.90m, Quantity = 20 });
        _entities.Add(new Part { Id = 3, Description = "Oil", Price = 15.00m, Quantity = 12 });
    }

    public Task<IEnumerable<Part>> GetPartsAsync()
    {
        return Task.FromResult<IEnumerable<Part>>(_entities);
    }

    public Task<Part> GetPartByIdAsync(int id)
    {

        return Task.FromResult(_entities.SingleOrDefault(x => x.Id == id));
    }

}