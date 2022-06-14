using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public class BusSchedule
    {

        [BsonElement("departingPlace")]
        public string DepartingPlace { get; set; }

        [BsonElement("departingPlaceURL")]
        public string DepartingPlaceURL { get; set; }

        [BsonElement("slots")]
        public List<BusScheduleSlot> Slots { get; set; }

    }
}