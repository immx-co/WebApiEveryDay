using Microsoft.AspNetCore.Mvc;
using web.api.orders.BusinessLogic;
using web.api.orders.BusinessLogic.RequestModels;

namespace web.api.orders.Controllers;

[ApiController]
[Route("api/v1")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpPost("createItem")]
    public async Task<IActionResult> CreateItemAsync(ItemRequest item)
    {
        return Ok(await _itemService.CreateAsync(item));
    }

    [HttpGet("getAllItems")]
    public async Task<IActionResult> GetAllItemsAsync()
    {
        return Ok(await _itemService.GetAllAsync());
    }
}
