using PartsStoreAPI.Core.Interfaces;
using PartStore.Application.Interfaces.Repositories;
using PartStore.Domain.Entities;

namespace PartStore.Infrastructure.Implementations.Services;

public class OrderService : IOrderService
{

    private readonly IOrderRepository _orderRepository;
    private readonly IPartRepository _partRepository;

    public OrderService(IOrderRepository orderRepository, IPartRepository partRepository)
    {
        _orderRepository = orderRepository;
        _partRepository = partRepository;
    }

    public async Task<Order> PlaceOrderAsync(Order order)
    {
        foreach (var lineItem in order.LineItems)
        {
            var part = await _partRepository.GetPartByIdAsync(lineItem.PartId);
            if (part is null)
                throw new Exception($"Part with ID {lineItem.PartId} not found.");

            lineItem.Total = lineItem.Quantity * part.Price;
        }

        order.TotalCost = order.LineItems.Sum(x => x.Total);
        return await _orderRepository.AddAsync(order);
    }
}