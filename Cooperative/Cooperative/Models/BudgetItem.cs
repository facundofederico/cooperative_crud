namespace Cooperative.Models;

public class BudgetItem
{
    // Gets the id of the item.
    public Item Item { get; }

    // Gets the item quantity.
    public int Quantity { get; }
    
    // Gets the item discount.
    public decimal Discount { get; }

    public BudgetItem(Item item, int quantity, decimal discount)
    {
        this.Item = item;
        this.Quantity = quantity;
        this.Discount = discount;
    }
    
    // Gets the total budget for this item.
    public decimal GetTotal()
    {
        return (Item.Price * Quantity * (1 - Discount));
    }
}