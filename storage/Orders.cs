using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace storage
{
    //[BsonIgnoreExtraElements]
    public class Orders : EntityBase
    {
        [BsonRequired]
        [BsonRepresentation(BsonType.Int32)]
        public int idorder { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal total { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string folio { get; set; }


        [BsonRequired]
        public string clientname { get; set; }

        [MinLength(1, ErrorMessage = "Debe existir detalles de order")]
        public List<OrderDetails> details { get; set; }
    }
}
