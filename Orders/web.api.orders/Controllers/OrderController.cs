using Microsoft.AspNetCore.Mvc;
using web.api.orders.BusinessLogic;
using web.api.orders.BusinessLogic.RequestModels;

namespace web.api.orders.Controllers;

[ApiController]
[Route("api/v1")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("createOrder")]
    public async Task<IActionResult> CreateOrderAsync(OrderRequest orderRequest)
    {
        try
        {
            return Ok(await _orderService.CreateAsync(orderRequest));
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getOrderById/{id:guid}")]
    public async Task<IActionResult> GetOrderByIdAsync(Guid id)
    {
        try
        {
            return Ok(await _orderService.GetByIdAsync(id));
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
