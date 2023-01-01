using Microsoft.AspNetCore.Mvc;
using Cooperative.Contracts.Items;
using Cooperative.Models;
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
    public IActionResult CreateItem(CreateItemRequest request)
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
        catch (ArgumentException)
        {
            return BadRequest();
        }
        
        this._itemService.CreateItem(item);

        var response = MapItemToResponse(item);
        
        return CreatedAtAction(
            actionName: nameof(GetItem),
            routeValues: new { id = item.Id },
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetItem(Guid id)
    {
        try
        {
            Item item = _itemService.GetItem(id);

            var response = MapItemToResponse(item);

            return Ok(response);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertItem(Guid id, UpsertItemRequest request)
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
        catch (ArgumentException)
        {
            return BadRequest();
        }

        try
        {
            _itemService.UpsertItem(item);

            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            var response = MapItemToResponse(item);

            return CreatedAtAction(
                actionName: nameof(GetItem),
                routeValues: new { id = item.Id },
                value: response);
        }
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteItem(Guid id)
    {
        try
        {
            _itemService.DeleteItem(id);

            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    private static ItemResponse MapItemToResponse(Item item)
    {
        var response = new ItemResponse(
                Id: item.Id,
                Name: item.Name,
                Description: item.Description,
                Price: item.Price
            );

        return response;
    }
}