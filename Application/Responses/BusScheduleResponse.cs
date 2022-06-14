using System.Collections.Generic;
using Domain;
using MongoDB.Bson;

namespace Application.Responses
{
    public class BusScheduleResponse
    {
        public ObjectId BusScheduleID { get; set; }

        public string DepartingPlace { get; set; }

        public string DepartingPlaceURL { get; set; }

        public List<BusScheduleSlot> Slots { get; set; }

    }
}