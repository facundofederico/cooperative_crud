using Cooperative.Models.Exceptions;

namespace Cooperative.Models;

/// <summary>
/// Represents a <see cref="Budget">'s detail for an <see cref="Models.Item">.
/// </summary>
public class BudgetItem
{
    /// <summary>
    /// Gets the related <see cref="Models.Item">.
    /// </summary>
    public Item Item { get; }

    /// <summary>
    /// Gets the <see cref="Models.Item"> quantity.
    /// </summary>
    public int Quantity { get; }
    
    /// <summary>
    /// Gets the discount for this <see cref="Models.Item">.
    /// </summary>
    public decimal Discount { get; }

    /// <summary>
    /// Creates a new <see cref="BudgetItem">
    /// </summary>
    /// <param name="item">The related <see cref="Models.Item">.</param>
    /// <param name="quantity">The item quantity. Must be greater than 0.</param>
    /// <param name="discount">The discount for this item. Must be between 0 and 1.</param>
    /// <exception cref="InvalidQuantityException"> Thrown if the privided
    /// quantity is invalid.
    /// <exception cref="InvalidDiscountException"> Thrown if the privided
    /// discount is invalid.
    public BudgetItem(Item item, int quantity, decimal discount)
    {
        if (quantity < 1)
        {
            throw new InvalidQuantityException();
        }
        if (discount < 0 || discount > 1)
        {
            throw new InvalidDiscountException();
        }

        this.Item = item;
        this.Quantity = quantity;
        this.Discount = discount;
    }
    
    /// <summary>
    /// Gets the <see cref="BudgetItem">'s total. It multiplies the
    /// <see cref="Models.Item">'s price with the quantity and applies the discount.
    /// </summary>
    /// <returns>The total value.</returns>
    public decimal GetTotal()
    {
        return (Item.Price * Quantity * (1 - Discount));
    }
}