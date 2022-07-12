using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Queries.BusSchedules;
using Application.Requests;
using Application.Responses;
using Domain;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Controllers
{

    public class BusSchedulesController : BaseController
    {

        [HttpGet]

        public async Task<List<BusScheduleResponse>> GetAllSchedules()
        {

            return await Mediator.Send(new GetAllBusSchedules.Query { });

        }

        [HttpPost("{locationId}")]

        public async Task<IActionResult> CreateBusSchedule(string locationId,
            BusScheduleCreateRequest busScheduleCreateRequest)
        {
            await Mediator.Send(new CreateBusSchedule.Command
            {
                BusScheduleCreateRequest = busScheduleCreateRequest,
                LocationId = ObjectId.Parse(locationId)
            });

            return Ok();

        }

        [HttpPut("updateInformation/{locationId}")]

        public async Task<IActionResult> UpdateBusScheduleInformation(string locationId,
            BusScheduleInformationUpdateRequest busScheduleInformationUpdateRequest)
        {
            await Mediator.Send(new UpdateBusScheduleInformation.Command
            {
                BusScheduleInformationUpdateRequest = busScheduleInformationUpdateRequest,
                LocationId = ObjectId.Parse(locationId)
            });
            return Ok();

        }

        [HttpPut("updateSlots/{locationId}")]

        public async Task<IActionResult> UpdateBusScheduleSlots(string locationId,
            BusScheduleSlotsUpdateRequest busScheduleSlotsUpdateRequest)
        {
            await Mediator.Send(new UpdateBusScheduleSlots.Command
            {
                BusScheduleSlotsUpdateRequest = busScheduleSlotsUpdateRequest,
                LocationId = ObjectId.Parse(locationId)
            });
            return Ok();

        }

        [HttpDelete("{locationId}")]

        public async Task<IActionResult> DeleteBusSchedule(string locationId)
        {

            await Mediator.Send(new DeleteBusSchedule.Command { LocationId = ObjectId.Parse(locationId) });

            return Ok();

        }

    }
}