using CarFleetIO.Application.Commands;
using CarFleetIO.Infrastructure.EF.Identity;
using CarFleetIO.Shared.Abstractions.Commands;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarFleetIO.Api.Controllers
{
    public class RegisterUserController : BaseController
    {
        public RegisterUserController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUser command)
        {

            await _commandDispatcher.DispatchAsync(command);
            return Created();
        }
    }
}
