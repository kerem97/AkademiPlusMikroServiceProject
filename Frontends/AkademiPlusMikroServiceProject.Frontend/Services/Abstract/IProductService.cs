using AkademiPlusMikroServiceProject.Frontend.Models.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusMikroServiceProject.Frontend.Services.Abstract
{
    public interface IProductService
    {


        Task<List<ProductViewModel>> GetAllProduct();
        Task<bool> CreateProduct(CreateProductViewModel createProductViewModel);
        Task<bool> UpdateProduct(UpdateProductViewModel updateProductViewModel);
        Task<bool> DeleteProduct(string productId);
    }
}
