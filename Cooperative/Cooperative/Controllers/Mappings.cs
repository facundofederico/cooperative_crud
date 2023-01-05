using Cooperative.Contracts.Budgets;
using Cooperative.Contracts.Items;
using Cooperative.Models;

namespace Cooperative.Controllers;

public static class Mappings
{
    public static ItemResponse MapItemToResponse(Item item)
    {
        var response = new ItemResponse(
                Id: item.Id,
                Name: item.Name,
                Description: item.Description,
                Price: item.Price
            );

        return response;
    }

    public static BudgetResponse MapToBudgetResponse(Budget budget)
    {
        var items = budget.Detail.Select(x =>
        {
            var itemResponse = MapItemToResponse(x.Item);

            return new BudgetResponseItem(
                Item: itemResponse,
                Quantity: x.Quantity,
                Discount: x.Discount,
                Total: x.GetTotal());
        });

        var budgetResponse = new BudgetResponse(
            Date: budget.Date,
            Discount: budget.Discount,
            Total: budget.GetTotal(),
            Detail: items
        );

        return budgetResponse;
    }
}