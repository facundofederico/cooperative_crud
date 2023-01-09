using Cooperative.Models;

namespace Cooperative.Services.Items;

/// <summary>
/// Interface for an Item CRUD service.
/// </summary>
public interface IItemService
{
    /// <summary>
    /// Creates a new <see cref="Item">.
    /// </summary>
    /// <param name="item">The <see cref="Item"> to create.</param>
    /// <returns>A <see cref="Task"> that indicates that the operation is complete.</returns>
    /// <exception cref="Models.Exceptions.ItemAlreadyExistsException">Thrown when
    /// the <see cref="Item"> Id already exists.</exception>
    Task CreateItem(Item item);
    
    /// <summary>
    /// Gets an existing <see cref="Item">.
    /// </summary>
    /// <param name="id">The id of the desired <see cref="Item">.</param>
    /// <returns>A <see cref="Task"> with the desired <see cref="Item">.</returns>
    /// <exception cref="Models.Exceptions.ItemNotFoundException">Thrown when the
    /// provided Id was not found.</exception>
    Task<Item> GetItem(Guid id);
    
    /// <summary>
    /// Gets an enumerable of existing <see cref="Item">.
    /// </summary>
    /// <param name="id">An enumerable of ids of the desired <see cref="Item">s.</param>
    /// <returns>A <see cref="Task"> with the desired enumerable of <see cref="Item">s.</returns>
    /// <exception cref="Models.Exceptions.ItemNotFoundException">Thrown when a
    /// provided Id was not found.</exception>
    Task<IEnumerable<Item>> GetItems(IEnumerable<Guid> ids);
    
    /// <summary>
    /// Updates an existing <see cref="Item">. If it is not found, creates it.
    /// </summary>
    /// <param name="item">The <see cref="Item"> to upsert.</param>
    /// <returns>A <see cref="Task"> that indicates that the operation is complete.</returns>
    Task UpsertItem(Item item);
    
    /// <summary>
    /// Deletes an existing <see cref="Item">.
    /// </summary>
    /// <param name="id">The id of <see cref="Item"> to delete.</param>
    /// <returns>A <see cref="Task"> that indicates that the operation is complete.</returns>
    /// <exception cref="Models.Exceptions.ItemNotFoundException">Thrown when the
    /// provided Id was not found.</exception>
    Task DeleteItem(Guid id);
}