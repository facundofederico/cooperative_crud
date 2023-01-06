using Xunit;
using Cooperative.Services.Items;
using Cooperative.Models;
using Cooperative.Models.Exceptions;

namespace Cooperative.Tests;

public class BudgetTests
{
    [Fact]
    public void BudgetItem_GetTotal_ShouldGetTotal()
    {
        // Arrange
        var item = new Item(
            name: "Name",
            description: "Description",
            price: 100.0m
        );
        var budgetItem = new BudgetItem(
            item: item,
            quantity: 2,
            discount: 0.1m
        );

        // Act
        var total = budgetItem.GetTotal();

        // Assert
        Assert.Equal(180.0m, total);
    }

    [Fact]
    public void Budget_AddItem_ShouldStoreItems()
    {
        // Arrange
        var item1 = new Item(
            name: "Name",
            description: "Description",
            price: 100.0m
        );
        var item2 = new Item(
            name: "Name",
            description: "Description",
            price: 200.0m
        );
        var budgetItem1 = new BudgetItem(
            item: item1,
            quantity: 1,
            discount: 0.1m
        );
        var budgetItem2 = new BudgetItem(
            item: item2,
            quantity: 5,
            discount: 0.3m
        );
        var budget = new Budget(
            date: DateTime.UtcNow,
            discount: 0.2m
        );
        budget.AddItem(budgetItem1);
        budget.AddItem(budgetItem2);

        // Act
        var items = budget.Detail;

        // Assert
        Assert.Equal(2, items.Count());
    }

    [Fact]
    public void Budget_GetTotal_ShouldGetTotal()
    {
        // Arrange
        var item1 = new Item(
            name: "Name",
            description: "Description",
            price: 100.0m
        );
        var item2 = new Item(
            name: "Name",
            description: "Description",
            price: 200.0m
        );
        var budgetItem1 = new BudgetItem(
            item: item1,
            quantity: 1,
            discount: 0.1m
        );
        var budgetItem2 = new BudgetItem(
            item: item2,
            quantity: 5,
            discount: 0.3m
        );
        var budget = new Budget(
            date: DateTime.UtcNow,
            discount: 0.2m
        );
        budget.AddItem(budgetItem1);
        budget.AddItem(budgetItem2);

        // Act
        var total = budget.GetTotal();

        // Assert
        Assert.Equal(632.0m, total);
    }
}