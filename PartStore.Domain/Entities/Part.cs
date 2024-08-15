using PartStore.Domain.Common;

namespace PartStore.Domain.Entities;

public class Part : BaseDomainEntity
{
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
