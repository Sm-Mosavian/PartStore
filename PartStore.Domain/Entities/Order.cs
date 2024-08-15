using PartStore.Domain.Common;

namespace PartStore.Domain.Entities;
public class Order : BaseDomainEntity
{
   
    public List<LineItem> LineItems { get; set; }
    public decimal TotalCost { get; set; }

    public Order()
    {
        LineItems = new List<LineItem>();
    }
}