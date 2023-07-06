using AkademiPlusMikroServiceProje.Shared.Dtos;
using AkademiPlusMikroServiceProject.Frontend.Models.Catalog;
using AkademiPlusMikroServiceProject.Frontend.Services.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AkademiPlusMikroServiceProject.Frontend.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateCategoryViewModel>("category", createCategoryViewModel);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategory(string categoryId)
        {
            var response = await _httpClient.DeleteAsync($"category/{categoryId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var response = await _httpClient.GetAsync("category");
            var responseMessage = await response.Content.ReadFromJsonAsync<Response<List<CategoryViewModel>>>();
            return responseMessage.Data;

        }

        public async Task<bool> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateCategoryViewModel>("category", updateCategoryViewModel);
            return response.IsSuccessStatusCode;
        }
    }
}
