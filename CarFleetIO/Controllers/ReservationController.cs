using CarFleetIO.Application.Commands;
using CarFleetIO.Application.DTO;
using CarFleetIO.Application.Queries;
using CarFleetIO.Shared.Abstractions.Commands;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarFleetIO.Api.Controllers
{
    public class ReservationController : BaseController
    {
        public ReservationController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] MakeReservation command)
        {

            await _commandDispatcher.DispatchAsync(command);
            return Created();
        }

        [HttpGet("getmyreservations")]


        public async Task<ActionResult<IEnumerable<ReservationDTO>>> Get([FromQuery] GetMyReservations query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpGet("getdatesbyvin")]

        public async Task<ActionResult<List<string>>> GetReservedDates([FromQuery] GetAllReservedDatesForVin query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }
    }
}
