namespace Cooperative.Models;

public class Budget
{
    // Gets the date of the budget.
    public DateTime Date { get; }
    
    // Gets the discount for the budget.
    public decimal Discount { get; }

    // Gets budget items.
    public List<BudgetItem> Detail { get; } = new();

    public Budget(DateTime date, decimal discount)
    {
        this.Date = date;
        this.Discount = discount;
    }

    public void AddItem(BudgetItem item)
    {
        this.Detail.Add(item);
    }

    public decimal GetTotal()
    {
        var subtotal = this.Detail.Sum(x => x.GetTotal());

        return subtotal * (1 - this.Discount);
    }
}