
using PartStore.Application.Interfaces.Repositories;
using PartStore.Domain.Entities;

namespace PartStore.Infrastructure.Implementations.Repositories;

public class OrderRepository : GeneralRepository<Order>,IOrderRepository
{

}