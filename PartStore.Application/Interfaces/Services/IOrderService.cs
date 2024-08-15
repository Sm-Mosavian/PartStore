using PartStore.Domain.Entities;

namespace PartsStoreAPI.Core.Interfaces;

public interface IOrderService
{
    Task<Order> PlaceOrderAsync(Order order);

}
