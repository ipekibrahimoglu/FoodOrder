using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        public MenuItemsController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _menuItemService.GetAllAsync();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _menuItemService.GetByIdAsync(id);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("bymenu/{menuId}")]
        public async Task<IActionResult> GetMenuItemsByMenuId(Guid menuId)
        {
            var result = await _menuItemService.GetMenuItemsByMenuIdAsync(menuId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        //Artirilabilir
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string name, [FromQuery] Guid? menuId,
            [FromQuery] decimal? min, [FromQuery] decimal? max)
        {
            var result = await _menuItemService.GetByConditionAsync(mi =>
                (string.IsNullOrEmpty(name) || mi.Name.Contains(name))
                && (!menuId.HasValue || mi.MenuId == menuId.Value) && (!min.HasValue || mi.Price >= min.Value)
                && (!max.HasValue || mi.Price <= max.Value));
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }


        //Gerekirse HTTP status codelarda Created(), NotFound() gibi yapilar kullanilabilir
        [HttpPost]
        public async Task<IActionResult> Add(MenuItem entity)
        {
            var result = await _menuItemService.AddAsync(entity);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update(MenuItem entity)
        {
            var result = await _menuItemService.UpdateAsync(entity);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _menuItemService.DeleteAsync(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
