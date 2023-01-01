using Cooperative.Models;

namespace Cooperative.Services.Items;

public interface IItemService
{
    // Persists the provided item as a new object.
    void CreateItem(Item item);
    
    // Gets the item that matches the provided id.
    Item GetItem(Guid id);
    
    // Updates the item that matches the provided id.
    // If not found, creates it.
    void UpsertItem(Item item);
    
    // Deletes the item that matches the provided id.
    void DeleteItem(Guid id);
}