using Xunit;
using Cooperative.Services.Items;
using Cooperative.Models;
using Cooperative.Models.Exceptions;

namespace Cooperative.Tests;

public abstract class ItemsServiceTests
{
    protected abstract IItemService GetService();

    [Fact]
    public async void CreateItem_NewItem_ShouldNotThrowExceptions()
    {
        // Arrange
        var itemService = GetService();
        var item = new Item(
            name: "Name",
            description: "Description",
            price: 1.0m
        );

        // Assert
        await itemService.CreateItem(item);
    }

    [Fact]
    public async void CreateItem_SecondItem_ShouldNotThrowExceptions()
    {
        // Arrange
        var itemService = GetService();
        var item1 = new Item(
            name: "Name 1",
            description: "Description",
            price: 1.0m
        );
        var item2 = new Item(
            name: "Name 2",
            description: "Description",
            price: 1.0m
        );

        // Act
        await itemService.CreateItem(item1);

        // Assert
        await itemService.CreateItem(item2);
    }

    [Fact]
    public async void CreateItem_ExistingItem_ShouldThrowException()
    {
        // Arrange
        var itemService = GetService();
        var item = new Item(
            name: "Name",
            description: "Description",
            price: 1.0m
        );

        // Act
        await itemService.CreateItem(item);

        // Assert
        await Assert.ThrowsAsync<ItemAlreadyExistsException>(() =>
            itemService.CreateItem(item)
        );
    }

    [Fact]
    public async void GetItem_ExistingItem_ShouldGetTheItem()
    {
        // Arrange
        var itemService = GetService();
        var item = new Item(
            name: "Name",
            description: "Description",
            price: 1.0m
        );
        await itemService.CreateItem(item);

        // Act
        var obtainedItem = await itemService.GetItem(item.Id);

        // Assert
        Assert.Equal(item.Id, obtainedItem.Id);
        Assert.Equal(item.Name, obtainedItem.Name);
        Assert.Equal(item.Description, obtainedItem.Description);
        Assert.Equal(item.Price, obtainedItem.Price);
    }

    [Fact]
    public async void GetItem_InexistentItem_ShouldThrowException()
    {
        // Arrange
        var itemService = GetService();
        var id = Guid.NewGuid();

        // Assert
        await Assert.ThrowsAsync<ItemNotFoundException>(() => itemService.GetItem(id));
    }

    [Fact]
    public async void GetItems_ExistingItems_ShouldGetTheItems()
    {
        // Arrange
        var itemService = GetService();
        var item1 = new Item(
            name: "Name1",
            description: "Description",
            price: 1.0m
        );
        var item2 = new Item(
            name: "Name2",
            description: "Description",
            price: 1.0m
        );
        var item3 = new Item(
            name: "Name3",
            description: "Description",
            price: 1.0m
        );
        
        await itemService.CreateItem(item1);
        await itemService.CreateItem(item2);
        await itemService.CreateItem(item3);

        var requestedItems = new[] { item1.Id, item2.Id };

        // Act
        var obtainedItems = await itemService.GetItems(requestedItems);

        // Assert
        Assert.Equal(2, obtainedItems.Count());
        Assert.Contains(obtainedItems, x => x.Id == item1.Id);
        Assert.Contains(obtainedItems, x => x.Id == item2.Id);
    }

    [Fact]
    public async void GetItems_InexistentItem_ShouldThrowException()
    {
        // Arrange
        var itemService = GetService();
        var item = new Item(
            name: "Name",
            description: "Description",
            price: 1.0m
        );
        await itemService.CreateItem(item);

        var requestedItems = new[] {item.Id, Guid.NewGuid()};

        // Assert
        await Assert.ThrowsAsync<ItemNotFoundException>(() =>
            itemService.GetItems(requestedItems));
    }

    [Fact]
    public async void GetItems_EmptyRequest_ShouldReturnEmptyList()
    {
        // Arrange
        var itemService = GetService();

        var items = await itemService.GetItems(new List<Guid>());

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async void UpsertItem_NewItem_ShouldCreateTheItem()
    {
        // Arrange
        var itemService = GetService();
        var item = new Item(
            name: "Name",
            description: "Description",
            price: 1.0m
        );

        // Act
        await itemService.UpsertItem(item);

        // Assert
        var obtainedItem = await itemService.GetItem(item.Id);

        Assert.Equal(item.Id, obtainedItem.Id);
        Assert.Equal(item.Name, obtainedItem.Name);
        Assert.Equal(item.Description, obtainedItem.Description);
        Assert.Equal(item.Price, obtainedItem.Price);
    }

    [Fact]
    public async void UpsertItem_ExistingItem_ShouldReplaceTheItem()
    {
        // Arrange
        var itemService = GetService();
        var oldItem = new Item(
            name: "Name",
            description: "Description",
            price: 1.0m
        );
        await itemService.CreateItem(oldItem);

        var newItem = new Item(
            id: oldItem.Id,
            name: "New Name",
            description: "New Description",
            price: 2.0m
        );

        // Act
        await itemService.UpsertItem(newItem);

        // Assert
        var obtainedItem = await itemService.GetItem(oldItem.Id);

        Assert.Equal(newItem.Id, obtainedItem.Id);
        Assert.Equal(newItem.Name, obtainedItem.Name);
        Assert.Equal(newItem.Description, obtainedItem.Description);
        Assert.Equal(newItem.Price, obtainedItem.Price);
    }

    [Fact]
    public async void DeleteItem_ExistingItem_ShouldDeleteTheItem()
    {
        // Arrange
        var itemService = GetService();
        var item = new Item(
            name: "Name",
            description: "Description",
            price: 1.0m
        );
        await itemService.CreateItem(item);

        // Act
        await itemService.DeleteItem(item.Id);

        // Assert
        await Assert.ThrowsAsync<ItemNotFoundException>(() => itemService.GetItem(item.Id));
    }

    [Fact]
    public async void DeleteItem_InexistentItem_ShouldThrowException()
    {
        // Arrange
        var itemService = GetService();
        var id = Guid.NewGuid();

        // Assert
        await Assert.ThrowsAsync<ItemNotFoundException>(() => itemService.DeleteItem(id));
    }
}