using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace storage
{
    public class OrderDetails
    {
        
        [BsonRepresentation(BsonType.Decimal128)]
        [BsonRequired]
        public decimal unitPrice { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        [BsonRequired]
        public decimal amount { get; set; }
        
        [BsonRequired]
        public int idproduct { get; set; }
    }
}
