namespace Cooperative.Contracts.Budgets;

public record BudgetRequestItem(
    Guid ItemId,
    int Quantity,
    decimal Discount
);