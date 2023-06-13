using AkademiPlusMikroServiceProject.Catalog.Dtos;
using AkademiPlusMikroServiceProject.Catalog.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AkademiPlusMikroServiceProject.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var categories = await _categoryService.GetByIDAsync(id);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var categories = await _categoryService.DeleteAsync(id);
            return Ok();
        }
        [HttpPost]

        public async Task<IActionResult> AddCategory(CreateCategoryDto createCategoryDto)
        {
            var categories = await _categoryService.CreateAsync(createCategoryDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var categories = await _categoryService.UpdateAsync(updateCategoryDto);
            return Ok();
        }
    }
}
