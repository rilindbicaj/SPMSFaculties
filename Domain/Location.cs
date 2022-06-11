using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public class Location
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId LocationId { get; set; }

        [BsonElement("locationName")]
        public string LocationName { get; set; }

        [BsonElement("busSchedule")]
        public BusSchedule BusSchedule { get; set; }

    }
}