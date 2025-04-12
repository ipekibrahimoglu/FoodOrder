using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _restaurantService.GetAllAsync();
            return result.Success
                ? Ok(result.Data)
                : BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _restaurantService.GetByIdAsync(id);
            return result.Success
                ? Ok(result.Data)
                : NotFound(result.Message);
        }

        [HttpGet("byowner/{ownerId}")]
        public async Task<IActionResult> GetRestaurantsByOwnerId(Guid ownerId)
        {
            var result = await _restaurantService.GetRestaurantsByOwnerIdAsync(ownerId);
            return result.Success
                ? Ok(result.Data)
                : BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Restaurant restaurant)
        {
            var result = await _restaurantService.AddAsync(restaurant);
            return result.Success
                ? Ok(result.Message)
                : BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Restaurant restaurant)
        {
            var result = await _restaurantService.UpdateAsync(restaurant);
            return result.Success
                ? Ok(result.Message)
                : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _restaurantService.DeleteAsync(id);
            return result.Success
                ? Ok(result.Message)
                : BadRequest(result.Message);
        }
    }
}
