using CarFleetIO.Application.Commands;
using CarFleetIO.Shared.Abstractions.Commands;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CarFleetIO.Api.Controllers
{
    public class ReservationController : BaseController
    {
        public ReservationController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MakeReservation command)
        {

            await _commandDispatcher.DispatchAsync(command);
            return Created();
        }
    }
}
