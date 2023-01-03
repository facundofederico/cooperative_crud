using Cooperative.Models;

namespace Cooperative.Services.Items;

public interface IItemService
{
    // Persists the provided item as a new object.
    // Throws an ItemAlreadyExistsException if an item with the same Id was found.
    Task CreateItem(Item item);
    
    // Gets the item that matches the provided id.
    // Throws an ItemNotFoundException if an item with that id was not found.
    Task<Item> GetItem(Guid id);
    
    // Updates the item that matches the provided id.
    // If not found, creates it.
    Task UpsertItem(Item item);
    
    // Deletes the item that matches the provided id.
    // Throws an ItemNotFoundException if an item with that id was not found.
    Task DeleteItem(Guid id);
}