using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.SeasonStatuses;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonStatusesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<SeasonStatusDto>>> List()
        {
            return await Mediator.Send(new ListSeasonStatuses.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeasonStatusDto>> Details(int id)
        {
            return await Mediator.Send(new Details.Query { SeasonStatusID = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(SeasonStatus seasonStatus)
        {
            return await Mediator.Send(new Create.Command { SeasonStatus = seasonStatus });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, SeasonStatus seasonStatus)
        {
            //command.SeasonStatus.SeasonStatusID = id;
            return await Mediator.Send(new Edit.Command { SeasonStatus = seasonStatus });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new Delete.Command { SeasonStatusID = id });
        }
    }
}

