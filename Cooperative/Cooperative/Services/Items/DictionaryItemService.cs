using System.Data;
using Cooperative.Models;

namespace Cooperative.Services.Items;

public class DictionaryItemService : IItemService
{
    private static readonly Dictionary<Guid, Item> _items = new();

    public void CreateItem(Item item)
    {
        if (_items.TryGetValue(item.Id, out Item? existing_item))
        {
            var msg = String.Format("An item with id: {0} already exists", item.Id);

            throw new DuplicateNameException(msg);
        }
        else
        {
            _items.Add(item.Id, item);
        }
    }
    
    public Item GetItem(Guid id)
    {
        if (_items.TryGetValue(id, out Item? item))
        {
            return item;
        }
        else
        {
            var msg = String.Format("The item with id: {0} was not found", id);

            throw new KeyNotFoundException(msg);
        }
    }
    
    public void UpsertItem(Item item)
    {
        if (_items.TryGetValue(item.Id, out Item? existing_item))
        {
            _items[item.Id] = item;
        }
        else
        {
            _items.Add(item.Id, item);

            var msg = String.Format("The item with id: {0} was not found", item.Id);

            throw new KeyNotFoundException();
        }
    }
    
    public void DeleteItem(Guid id)
    {
        if (!_items.Remove(id))
        {
            var msg = String.Format("The item with id: {0} was not found", id);

            throw new KeyNotFoundException(msg);
        }
    }
}