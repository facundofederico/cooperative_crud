namespace Cooperative.Contracts.Items;

public record CreateItemRequest(
    string Name,
    string Description,
    decimal Price
);