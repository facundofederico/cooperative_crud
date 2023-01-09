using Microsoft.AspNetCore.Mvc;
using Cooperative.Contracts.Budgets;
using Cooperative.Models;
using Cooperative.Models.Exceptions;
using Cooperative.Services.Items;

namespace Cooperative.Controllers;

[ApiController]
[Route("[controller]")]
public class BudgetsController : ControllerBase
{
    private readonly IItemService _itemsService;

    public BudgetsController(IItemService itemsService)
    {
        this._itemsService = itemsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBudget(GetBudgetRequest request)
    {
        if (!request.Items.Any())
        {
            return BadRequest();
        }

        var itemIds = request.Items.Select(x => x.ItemId);
        IEnumerable<Item> items;

        try
        {
            items = await _itemsService.GetItems(itemIds);
        }
        catch (ItemNotFoundException)
        {
            return BadRequest();
        }

        var budget = new Budget(discount: request.Discount);

        foreach (Item item in items)
        {
            var requestItem = request.Items.First(x => x.ItemId == item.Id);

            try
            {
                var budgetItem = new BudgetItem(
                    item: item,
                    quantity: requestItem.Quantity,
                    discount: requestItem.Discount
                );
                
                budget.AddItem(budgetItem);
            }
            catch (InvalidQuantityException)
            {
                return BadRequest(ErrorResponses.InvalidQuantity);
            }
            catch (InvalidDiscountException)
            {
                return BadRequest(ErrorResponses.InvalidDiscount);
            }
        };

        var response = Mappings.MapToBudgetResponse(budget);

        return Ok(response);
    }
}