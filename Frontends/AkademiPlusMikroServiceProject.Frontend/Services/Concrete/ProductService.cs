using AkademiPlusMikroServiceProje.Shared.Dtos;
using AkademiPlusMikroServiceProject.Frontend.Models.Catalog;
using AkademiPlusMikroServiceProject.Frontend.Services.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AkademiPlusMikroServiceProject.Frontend.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateProduct(CreateProductViewModel createProductViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateProductViewModel>("product", createProductViewModel);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProduct(string productId)
        {

            var response = await _httpClient.DeleteAsync($"product/{productId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<ProductViewModel>> GetAllProduct()
        {
            var response = await _httpClient.GetAsync("product");
            var responseMessage = await response.Content.ReadFromJsonAsync<Response<List<ProductViewModel>>>();
            return responseMessage.Data;
        }

        public async Task<bool> UpdateProduct(UpdateProductViewModel updateProductViewModel)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateProductViewModel>("product", updateProductViewModel);
            return response.IsSuccessStatusCode;
        }
    }
}
