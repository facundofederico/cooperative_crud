namespace Cooperative.Models;

/// <summary>
/// Represents a requested budget for a selection of <see cref="Item">s.
/// </summary>
public class Budget
{
    private readonly List<BudgetItem> detail = new();

    /// <summary>
    /// Gets the UTC <see cref="DateTime"> in which the <see cref="Budget"> was created.
    /// </summary>
    public DateTime Date { get; }
    
    /// <summary>
    /// Gets the discount applied to the budget.
    /// </summary>
    public decimal Discount { get; }

    /// <summary>
    /// Gets an enumerable of <see cref="BudgetItem">s.
    /// </summary>
    public IEnumerable<BudgetItem> Detail => this.detail;

    /// <summary>
    /// Creates a new <see cref="Budget">.
    /// </summary>
    /// <param name="discount">The discount to be applied to the budget.</param>
    public Budget(decimal discount)
    {
        this.Date = DateTime.UtcNow;
        this.Discount = discount;
    }

    /// <summary>
    /// Adds a <see cref="BudgetItem"> to the Detail.
    /// </summary>
    /// <param name="item">The <see cref="BudgetItem"> to add.</param>
    public void AddItem(BudgetItem item)
    {
        this.detail.Add(item);
    }

    /// <summary>
    /// Gets the <see cref="Budget">'s total. It sums the total of each
    /// <see cref="BudgetItem"> and applies the discount.
    /// </summary>
    /// <returns>The total value.</returns>
    public decimal GetTotal()
    {
        var subtotal = this.Detail.Sum(x => x.GetTotal());

        return subtotal * (1 - this.Discount);
    }
}