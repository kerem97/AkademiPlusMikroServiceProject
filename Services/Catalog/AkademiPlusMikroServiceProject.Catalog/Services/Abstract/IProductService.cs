using AkademiPlusMikroServiceProje.Shared.Dtos;
using AkademiPlusMikroServiceProject.Catalog.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusMikroServiceProject.Catalog.Services.Abstract
{
    public interface IProductService
    {
        Task<Response<List<ProductDto>>> GetAllAsync();
        Task<Response<ProductDto>> CreateAsync(CreateProductDto createProductDto);

        Task<Response<ProductDto>> GetByIDAsync(string id);
        Task<Response<NoContent>> UpdateAsync(UpdateProductDto updateProductDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
