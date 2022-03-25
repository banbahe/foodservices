using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace storage
{
    //[BsonIgnoreExtraElements]
    public class Products : EntityBase
    {
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string name { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string sku { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonDefaultValue("")]
        public string imgPath { get; set; }

        [BsonRequired]
        [BsonDefaultValue(0)]
        public int idproduct { get; set; }

        
        [BsonRepresentation(BsonType.Decimal128)]
        [BsonRequired]
        public decimal unitPrice { get; set; }

        
        [BsonRepresentation(BsonType.Decimal128)]
        [BsonRequired]
        public decimal existence { get; set; }


    }
}
