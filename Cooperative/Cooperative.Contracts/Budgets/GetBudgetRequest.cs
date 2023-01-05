namespace Cooperative.Contracts.Budgets;

public record GetBudgetRequest(
    IEnumerable<BudgetRequestItem> Items,
    decimal Discount
);