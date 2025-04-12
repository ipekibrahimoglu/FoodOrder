using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderItemService.GetAllAsync();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _orderItemService.GetByIdAsync(id);
            return result.Success
                ? Ok(result.Data)
                : NotFound(result.Message);
        }

        [HttpGet("byorder/{orderId}")]
        public async Task<IActionResult> GetOrderItemsByOrderId(Guid orderId)
        {
            var result = await _orderItemService.GetOrderItemsByOrderId(orderId);
            return result.Success
                ? Ok(result.Data)
                : BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderItem orderItem)
        {
            var result = await _orderItemService.AddAsync(orderItem);
            return result.Success
                ? Ok(result.Message)
                : BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update(OrderItem orderItem)
        {
            var result = await _orderItemService.UpdateAsync(orderItem);
            return result.Success
                ? Ok(result.Message)
                : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _orderItemService.DeleteAsync(id);
            return result.Success
                ? Ok(result.Message)
                : BadRequest(result.Message);
        }
    }
}

