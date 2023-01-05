namespace Cooperative.Contracts.Budgets;

public record BudgetResponse(
    DateTime Date,
    decimal Discount,
    decimal Total,
    IEnumerable<BudgetResponseItem> Detail
);