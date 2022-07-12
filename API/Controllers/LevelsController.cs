using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Levels;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class LevelsController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<List<LevelDto>>> List()
        {
            return await Mediator.Send(new ListLevels.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LevelDto>> Details(int id)
        {
            return await Mediator.Send(new Details.Query { LevelID = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Level level)
        {
            return await Mediator.Send(new Create.Command { Level = level });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Level level)
        {
            //command.Level.LevelID = id;
            return await Mediator.Send(new Edit.Command { Level = level });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new Delete.Command { LevelID = id });
        }
    }
}