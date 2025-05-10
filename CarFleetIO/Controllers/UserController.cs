using CarFleetIO.Application.Commands;
using CarFleetIO.Shared.Abstractions.Commands;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Input;

namespace CarFleetIO.Api.Controllers
{
    public class UserController: BaseController
    {
        public UserController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {

            await _commandDispatcher.DispatchAsync(command);
            return Created();
        }

        [HttpPut("User/{username}")]
        public async Task<IActionResult> Put([FromBody] ChangeLastName command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }


    }
}
