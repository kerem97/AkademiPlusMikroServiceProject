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
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;

        }
        public async Task<Response<ProductDto>> CreateAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(product);
            return Response<ProductDto>.Success(200);

        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _productCollection.DeleteOneAsync(x => x.ProductID == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail(404, "Id Bulunamadı");
            }
        }

        public async Task<Response<List<ProductDto>>> GetAllAsync()
        {
            var products = await _productCollection.Find(product => true).ToListAsync();
            return Response<List<ProductDto>>.Success(200, _mapper.Map<List<ProductDto>>(products));
        }

        public async Task<Response<ProductDto>> GetByIDAsync(string id)
        {
            var product = await _productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return Response<ProductDto>.Fail(404, "Ürün Bulunamadı");
            }
            else
            {
                return Response<ProductDto>.Success(200, _mapper.Map<ProductDto>(product));
            }
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.CategoryID, product);
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
