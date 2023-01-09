using Microsoft.AspNetCore.Mvc;
using Cooperative.Contracts.Items;
using Cooperative.Models;
using Cooperative.Models.Exceptions;
using Cooperative.Services.Items;

namespace Cooperative.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        this._itemService = itemService;
    }

    [HttpPost()]
    public async Task<IActionResult> CreateItem(CreateItemRequest request)
    {
        Item item;
        try
        {
            item = new Item(
                name: request.Name,
                description: request.Description,
                price: request.Price
            );
        }
        catch (InvalidNameException)
        {
            return BadRequest(ErrorResponses.InvalidName);
        }
        catch (InvalidDescriptionException)
        {
            return BadRequest(ErrorResponses.InvalidDescription);
        }
        catch (InvalidPriceException)
        {
            return BadRequest(ErrorResponses.InvalidPrice);
        }
        
        await this._itemService.CreateItem(item);

        var response = Mappings.MapItemToResponse(item);
        
        return CreatedAtAction(
            actionName: nameof(GetItem),
            routeValues: new { id = item.Id },
            value: response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetItem(Guid id)
    {
        try
        {
            Item item = await _itemService.GetItem(id);

            var response = Mappings.MapItemToResponse(item);

            return Ok(response);
        }
        catch (ItemNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpsertItem(Guid id, UpsertItemRequest request)
    {
        Item item;
        try
        {
            item = new Item(
                id: id,
                name: request.Name,
                description: request.Description,
                price: request.Price
            );
        }
        catch (InvalidNameException)
        {
            return BadRequest(ErrorResponses.InvalidName);
        }
        catch (InvalidDescriptionException)
        {
            return BadRequest(ErrorResponses.InvalidDescription);
        }
        catch (InvalidPriceException)
        {
            return BadRequest(ErrorResponses.InvalidPrice);
        }

        await _itemService.UpsertItem(item);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteItem(Guid id)
    {
        try
        {
            await _itemService.DeleteItem(id);

            return NoContent();
        }
        catch (ItemNotFoundException)
        {
            return NotFound();
        }
    }
}