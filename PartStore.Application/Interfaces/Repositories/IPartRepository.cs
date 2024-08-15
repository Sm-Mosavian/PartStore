
using PartsStoreAPI.Core.Interfaces;
using PartStore.Domain.Entities;

namespace PartStore.Application.Interfaces.Repositories;

public interface IPartRepository : IGeneralRepository<Part>
{
    Task<IEnumerable<Part>> GetPartsAsync();
    Task<Part> GetPartByIdAsync(int id);

}