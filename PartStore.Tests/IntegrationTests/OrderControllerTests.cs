using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using PartStore.Domain.Entities;

namespace PartStore.Tests.IntegrationTests
{
    public class OrderControllerTests
    {
        private readonly HttpClient _client;

        public OrderControllerTests()
        {
            var factory = new WebApplicationFactory<Program>();
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PlaceOrder_ValidOrder_ReturnsCreated()
        {
            // Arrange

            var order = new Order
            {
                Id=1,
                LineItems = new List<LineItem>
                {
                    new (   1,  2 ,1),
                    new (   2,  3 ,1)

                }
            };

            // Act
            var response = await _client.PostAsJsonAsync("api/orders", order);
            response.EnsureSuccessStatusCode();

            // Assert
            var createdOrder = await response.Content.ReadFromJsonAsync<Order>();
            Assert.Equal(1, createdOrder.Id);
            Assert.Equal(2, createdOrder.LineItems.Count);
            Assert.Equal(26.68M, createdOrder.TotalCost); // Assuming calculated total cost
        }

        [Fact]
        public async Task PlaceOrder_InvalidLineItem_ReturnsBadRequest()
        {
            // Arrange
            var order = new Order
            {
                LineItems = new List<LineItem>
                {
                    new (   1,  2 ,1),
                    new (   99,  3 ,1) // Invalid Part ID
                }
            };

            // Act
            var response = await _client.PostAsJsonAsync("api/orders", order);

            // Assert
            Assert.True(!response.IsSuccessStatusCode);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("Part with ID 99 not found.", responseContent);
        }

 

   

    }
}