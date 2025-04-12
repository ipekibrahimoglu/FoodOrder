using System.ComponentModel.Design;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _menuService.GetAllASync();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _menuService.GetByIdAsync(id);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("byrestaurant/{restaurantId}")]
        public async Task<IActionResult> GetMenusByRestaurantId(Guid restaurantId)
        {
            var result = await _menuService.GetMenusByRestaurantId(restaurantId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }


        //Sık kullanılan kategorilendirmeye göre burası cogaltilabilir
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string name, [FromQuery] Guid? restaurantId)
        {
            var result = await _menuService.GetByConditionASync(
                m => (string.IsNullOrEmpty(name) || m.Name.Contains(name))
                     && (!restaurantId.HasValue || m.RestaurantId == restaurantId));

            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Menu entity)
        {
            var result = await _menuService.AddAsync(entity);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Menu entity)
        {
            var result = await _menuService.UpdateAsync(entity);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _menuService.DeleteAsync(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
