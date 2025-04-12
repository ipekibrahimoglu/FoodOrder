using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _reviewService.GetAllAsync();
            return result.Success
                ? Ok(result.Data)
                : BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _reviewService.GetByIdAsync(id);
            return result.Success
                ? Ok(result.Data)
                : NotFound(result.Message);
        }

        [HttpGet("byrestaurant/{restaurantId}")]
        public async Task<IActionResult> GetReviewsByRestaurant(Guid restaurantId)
        {
            var result = await _reviewService.GetReviewsByRestaurantId(restaurantId);
            return result.Success
                ? Ok(result.Data)
                : BadRequest(result.Message);
        }

        [HttpGet("byuser/{userId}")]
        public async Task<IActionResult> GetReviewsByUserId(Guid userId)
        {
            var result = await _reviewService.GetReviewsByUserId(userId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Review review)
        {
            var result = await _reviewService.AddAsync(review);
            return result.Success
                ? Ok(result.Message)
                : BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Review review)
        {
            var result = await _reviewService.UpdateAsync(review);
            return result.Success
                ? Ok(result.Message)
                : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _reviewService.DeleteAsync(id);
            return result.Success
                ? Ok(result.Message)
                : BadRequest(result.Message);
        }
    }
}
