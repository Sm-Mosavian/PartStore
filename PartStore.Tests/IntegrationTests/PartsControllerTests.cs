using Newtonsoft.Json;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PartStore.Domain.Entities;
using Moq;
using PartStore.Application.Interfaces.Repositories;
using PartStore.Infrastructure.Implementations.Services;



namespace PartStore.Tests.IntegrationTests;

public class PartsControllerTests
{
    private readonly HttpClient _client;

    public PartsControllerTests()
    {
        var factory = new WebApplicationFactory<Program>();
        _client = factory.CreateClient();
 
    }
    [Fact]
    public async Task CreatePart_DuplicateDescription_ThrowsException()
    {
        // Arrange
        IEnumerable<Part> existingPart = new List<Part>
        {
            new Part { Id = 1, Description = "Wire", Price = 5.99m, Quantity = 5 },

        };

        var newPart = new Part { Description = "Wire", Price = 9.99m, Quantity = 10 };

        var mockPartRepository = new Mock<IPartRepository>();

        mockPartRepository.Setup(x => x.GetPartsAsync()).Returns(Task.FromResult(existingPart));


        var partService = new PartService(mockPartRepository.Object);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => partService.CreatePartAsync(newPart));
    }


    [Fact]
    public async Task GetParts_ReturnsParts()
    {
        // Act
        var response = await _client.GetAsync("api/parts");
        response.EnsureSuccessStatusCode();

        // Assert
        var parts = await response.Content.ReadFromJsonAsync<IEnumerable<Part>>();
        Assert.Equal(3, parts.Count());
        Assert.Collection(parts,
            part => Assert.Equal("Wire", part.Description),
            part => Assert.Equal("Fluid", part.Description),
            part => Assert.Equal("Oil", part.Description)
        );
    }

    [Fact]
    public async Task CreatePart_ReturnsCreatedPart()
    {
        // Arrange
        var newPart = new Part { Description = "New Part" };

        // Act
        var response = await _client.PostAsJsonAsync("api/parts", newPart);

        // Assert
        Assert.True(response.IsSuccessStatusCode);
        var createdPart = JsonConvert.DeserializeObject<Part>(await response.Content.ReadAsStringAsync());
        Assert.Equal("New Part", createdPart.Description);
    }


}