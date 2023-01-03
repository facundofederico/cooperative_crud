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
}