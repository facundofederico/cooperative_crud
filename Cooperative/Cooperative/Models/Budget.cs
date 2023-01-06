namespace Cooperative.Models;

public class Budget
{
    private readonly List<BudgetItem> detail = new();

    // Gets the date of the budget.
    public DateTime Date { get; }
    
    // Gets the discount for the budget.
    public decimal Discount { get; }

    // Gets budget items.
    public IEnumerable<BudgetItem> Detail => this.detail;

    public Budget(DateTime date, decimal discount)
    {
        this.Date = date;
        this.Discount = discount;
    }

    public void AddItem(BudgetItem item)
    {
        this.detail.Add(item);
    }

    public decimal GetTotal()
    {
        var subtotal = this.Detail.Sum(x => x.GetTotal());

        return subtotal * (1 - this.Discount);
    }
}