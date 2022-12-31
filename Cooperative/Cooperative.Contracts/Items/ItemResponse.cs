namespace Cooperative.Contracts.Items;

public record ItemResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price
);