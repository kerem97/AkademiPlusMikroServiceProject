
using AkademiPlusMikroServiceProject.Frontend.Models.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusMikroServiceProject.Frontend.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<bool> CreateCategory(CreateCategoryViewModel createCategoryViewModel);
        Task<bool> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel);
        Task<bool> DeleteCategory(string categoryId);
    }
}
