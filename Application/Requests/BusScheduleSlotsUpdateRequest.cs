using System.Collections.Generic;
using Domain;

namespace Application.Requests
{
    public class BusScheduleSlotsUpdateRequest
    {
        public List<BusScheduleSlotCreateRequest> Slots { get; set; }
    }
}