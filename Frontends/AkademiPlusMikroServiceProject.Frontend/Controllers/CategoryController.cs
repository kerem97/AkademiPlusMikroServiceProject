using AkademiPlusMikroServiceProject.Frontend.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMikroServiceProject.Frontend.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _categoryService.GetAllCategories();
            return View(values);
        }
    }
}
