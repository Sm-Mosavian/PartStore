using Moq;

using PartsStoreAPI.Core.Interfaces;
using PartStore.Application.Interfaces.Repositories;
using PartStore.Domain.Entities;
using PartStore.Infrastructure.Implementations.Services;

namespace PartStore.Tests.UnitTests;

public class PartServiceTests
{
    private readonly Mock<IPartRepository> _mockPartRepository;
    private readonly IPartService _partService;

    public PartServiceTests()
    {
        _mockPartRepository = new Mock<IPartRepository>();
        _partService = new PartService(_mockPartRepository.Object);
    }

    [Fact]
    public async Task GetAllParts_ReturnsInitialParts()
    {
        // Arrange
        IEnumerable<Part> expectedParts = new List<Part>
        {
            new Part { Id = 1, Description = "Wire", Price = 5.99m, Quantity = 5 },
            new Part { Id = 2, Description = "Fluid", Price = 4.90m, Quantity = 20 },
            new Part { Id = 3, Description = "Oil", Price = 15.00m, Quantity = 12 }
        };

        _mockPartRepository.Setup(x => x.GetPartsAsync()).Returns(Task.FromResult(expectedParts));

        // Act
        var parts = await _partService.GetAllPartsAsync();

        // Assert
        Assert.Equal(expectedParts, parts);
    }

    [Fact]
    public async Task CreatePart_ValidPart_ReturnsCreatedPart()
    {
        // Arrange
        var newPart = new Part { Description = "New Part", Price = 9.99m, Quantity = 10 };
        var expectedPart = new Part { Id = 1, Description = "New Part", Price = 9.99m, Quantity = 10 };


        _mockPartRepository.Setup(x => x.AddAsync(It.IsAny<Part>())).Returns(Task.FromResult(expectedPart));

        var partService = new PartService(_mockPartRepository.Object);

        // Act
        var createdPart = await partService.CreatePartAsync(newPart);

        // Assert
        Assert.Equal(expectedPart, createdPart);
    }

}