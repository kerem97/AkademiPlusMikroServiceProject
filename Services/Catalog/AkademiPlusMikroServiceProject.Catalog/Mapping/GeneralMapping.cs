using AkademiPlusMikroServiceProject.Catalog.Dtos;
using AkademiPlusMikroServiceProject.Catalog.Models;
using AutoMapper;

namespace AkademiPlusMikroServiceProject.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateCategoryDto>().ReverseMap();
            CreateMap<Product, UpdateCategoryDto>().ReverseMap();
        }
    }
}
