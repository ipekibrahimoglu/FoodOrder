using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderService.GetAllAsync();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _orderService.GetByIdAsync(id);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("byusers/{userId}")]
        public async Task<IActionResult> GetOrderByUserId(Guid userId)
        {
            var result = await _orderService.GetOrdersByUserIdAsync(userId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("byrestaurants/{restaurantId}")]
        public async Task<IActionResult> GetOrdersByRestaurantId(Guid restaurantId)
        {
            var result = await _orderService.GetOrdersByRestaurantIdAsync(restaurantId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Success);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Order entity)
        {
            var result = await _orderService.AddAsync(entity);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Order entity)
        {
            var result = await _orderService.UpdateAsync(entity);
            return result.Success ? Ok(result.Success) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _orderService.DeleteAsync(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
        //GetByConditionlar eklenebilir!
    }
}
