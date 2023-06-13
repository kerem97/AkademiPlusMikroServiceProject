using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AkademiPlusMikroServiceProject.Catalog.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }

    }
}
