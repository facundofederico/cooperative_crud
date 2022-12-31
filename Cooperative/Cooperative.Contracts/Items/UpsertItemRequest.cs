namespace Cooperative.Contracts.Items;

public record UpsertItemRequest(
    string Name,
    string Description,
    decimal Price
);