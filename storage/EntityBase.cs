using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace storage
{
    public class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        [BsonDefaultValue(0)]
        public int currentStatus { get; set; }


        [BsonDefaultValue(0)]
        public int dateEntry { get; set; }

    }
}