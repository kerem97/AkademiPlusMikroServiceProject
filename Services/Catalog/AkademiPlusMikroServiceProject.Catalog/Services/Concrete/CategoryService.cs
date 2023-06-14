using AkademiPlusMikroServiceProje.Shared.Dtos;
using AkademiPlusMikroServiceProject.Catalog.Dtos;
using AkademiPlusMikroServiceProject.Catalog.Models;
using AkademiPlusMikroServiceProject.Catalog.Services.Abstract;
using AkademiPlusMikroServiceProject.Catalog.Settings;
using AutoMapper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusMikroServiceProject.Catalog.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<CategoryDto>> CreateAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(category);
            return Response<CategoryDto>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _categoryCollection.DeleteOneAsync(x => x.CategoryID == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail(404, "Id Bulunamadı");
            }
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(200, _mapper.Map<List<CategoryDto>>(categories));
        }

        public async Task<Response<CategoryDto>> GetByIDAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return Response<CategoryDto>.Fail(404, "Kategori Bulunamadı");
            }
            else
            {
                return Response<CategoryDto>.Success(200, _mapper.Map<CategoryDto>(category));
            }
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            var result = await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryId, category);
            if (result == null)
            {
                return Response<NoContent>.Fail(404, "Kategori Bulunamadı");
            }
            else
            {
                return Response<NoContent>.Success(204);
            }
        }
    }
}
