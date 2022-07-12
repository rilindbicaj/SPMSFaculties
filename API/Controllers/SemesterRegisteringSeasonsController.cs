using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.SemesterRegisteringSeasons;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class SemesterRegisteringSeasonsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<SemesterRegisteringSeasonDto>>> List()
        {
            return await Mediator.Send(new ListSemesterRegisteringSeasons.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterRegisteringSeasonDto>> Details(int id)
        {
            return await Mediator.Send(new Details.Query { SemesterRegisteringSeasonID = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(SemesterRegisteringSeason semesterRegisteringSeason)
        {
            return await Mediator.Send(new Create.Command { SemesterRegisteringSeason = semesterRegisteringSeason });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, SemesterRegisteringSeason semesterRegisteringSeason)
        {
            //command.SemesterRegisteringSeason.SemesterRegisteringSeasonID = id;
            return await Mediator.Send(new Edit.Command { SemesterRegisteringSeason = semesterRegisteringSeason });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new Delete.Command { SemesterRegisteringSeasonID = id });
        }
    }
}