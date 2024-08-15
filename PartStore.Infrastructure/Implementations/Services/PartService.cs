using PartsStoreAPI.Core.Interfaces;
using PartStore.Application.Interfaces.Repositories;
using PartStore.Domain.Entities;
using System.Linq;

namespace PartStore.Infrastructure.Implementations.Services;

public class PartService : IPartService
{
    private readonly IPartRepository _partRepository;

    public PartService(IPartRepository partRepository)
    {
        _partRepository = partRepository;
    }

    public async Task<IEnumerable<Part>> GetAllPartsAsync()
    {
        return await _partRepository.GetPartsAsync();
    }


    public async Task<Part> CreatePartAsync(Part part)
    {
        var partsList = await _partRepository.GetPartsAsync();

        var existingPart = partsList.FirstOrDefault(p => p.Description.ToLower() == part.Description.ToLower());

        if (existingPart != null)
        {
            throw new ArgumentException("Part with the same description already exists.");
        }


        return await _partRepository.AddAsync(part);
    }


}