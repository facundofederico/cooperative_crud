namespace Cooperative.Models;

public class Budget
{
    // Gets the date of the budget.
    public DateTime Date { get; }
    
    // Gets the discount for the budget.
    public decimal Discount { get; }

    // Gets a description for the item.
    public IEnumerable<BudgetItem> Detail { get; } = new List<BudgetItem>();

    public Budget(DateTime date, decimal discount)
    {
        this.Date = date;
        this.Discount = discount;
    }

    public void AddItem(BudgetItem item)
    {
        this.Detail.Append(item);
    }

    public decimal GetTotal()
    {
        var subtotal = Detail.Sum(x => x.GetTotal());

        return subtotal * (1 - this.Discount);
    }
}