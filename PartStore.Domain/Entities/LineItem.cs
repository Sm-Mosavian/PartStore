using PartStore.Domain.Common;

namespace PartStore.Domain.Entities;

public class LineItem
{
    public int PartId { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }

    public LineItem(int partId, int quantity, decimal total)
    {
        PartId = partId;
        Quantity = quantity;
        Total = total;
    }

}