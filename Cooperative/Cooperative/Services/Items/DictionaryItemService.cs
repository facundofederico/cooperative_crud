using System.Data;
using Cooperative.Models;
using Cooperative.Models.Exceptions;

namespace Cooperative.Services.Items;

public class DictionaryItemService : IItemService
{
    private static readonly Dictionary<Guid, Item> _items = new();

    public Task CreateItem(Item item)
    {
        if (_items.TryGetValue(item.Id, out Item? existing_item))
        {
            throw new ItemAlreadyExistsException();
        }
        else
        {
            _items.Add(item.Id, item);
        }

        return Task.CompletedTask;
    }
    
    public Task<Item> GetItem(Guid id)
    {
        if (_items.TryGetValue(id, out Item? item))
        {
            return Task.FromResult(item);
        }
        else
        {
            throw new ItemNotFoundException();
        }
    }

    public async Task<IEnumerable<Item>> GetItems(IEnumerable<Guid> ids)
    {
        var tasks = ids.Select(x => GetItem(x));

        var items = await Task.WhenAll(tasks);

        return items;
    }
    
    public Task UpsertItem(Item item)
    {
        _items[item.Id] = item;

        return Task.CompletedTask;
    }
    
    public Task DeleteItem(Guid id)
    {
        if (!_items.Remove(id))
        {
            throw new ItemNotFoundException();
        }
        
        return Task.CompletedTask;
    }
}