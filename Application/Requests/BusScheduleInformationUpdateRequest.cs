using System.Collections.Generic;
using Domain;

namespace Application.Requests
{
    public class BusScheduleInformationUpdateRequest
    {
        public string DepartingPlace { get; set; }

        public string DepartingPlaceURL { get; set; }
        
    }
}