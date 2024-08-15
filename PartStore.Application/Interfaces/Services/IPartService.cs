using PartStore.Domain.Entities;

namespace PartsStoreAPI.Core.Interfaces;

public interface IPartService
{
    Task<IEnumerable<Part>> GetAllPartsAsync();
    Task<Part> CreatePartAsync(Part part);


}
