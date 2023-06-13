using AkademiPlusMikroServiceProject.Catalog.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AkademiPlusMikroServiceProject.Catalog.Dtos
{
    public class ProductDto
    {


        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }

        public string CategoryID { get; set; }

        public CategoryDto Category { get; set; }

    }
}
