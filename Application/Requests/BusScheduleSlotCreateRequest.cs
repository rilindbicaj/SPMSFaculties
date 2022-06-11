using MongoDB.Bson.Serialization.Attributes;

namespace Application.Requests
{
    public class BusScheduleSlotCreateRequest
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? SlotId { get; set; }

        [BsonElement("departTimeFromPlace")]
        public string DepartTimeFromPlace { get; set; }

        [BsonElement("departTimeFromFaculty")] 
        public string DepartTimeFromFaculty { get; set; }
    }
}