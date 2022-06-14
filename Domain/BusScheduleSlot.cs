using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public class BusScheduleSlot
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_id")]
        public ObjectId? SlotId { get; set; }

        [BsonElement("departTimeFromPlace")]
        public string DepartTimeFromPlace { get; set; }

        [BsonElement("departTimeFromFaculty")] 
        public string DepartTimeFromFaculty { get; set; }
        
    }
}