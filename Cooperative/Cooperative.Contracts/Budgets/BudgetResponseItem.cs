using Cooperative.Contracts.Items;

namespace Cooperative.Contracts.Budgets;

public record BudgetResponseItem(
    ItemResponse Item,
    int Quantity,
    decimal Discount,
    decimal Total
);