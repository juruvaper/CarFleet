using CarFleetIO.Application.Commands;
using CarFleetIO.Application.DTO;
using CarFleetIO.Application.Queries;
using CarFleetIO.Shared.Abstractions.Commands;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarFleetIO.Api.Controllers
{
    public class LocalizationController: BaseController
    {
        

        public LocalizationController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher): base(commandDispatcher, queryDispatcher)
        {

        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLocation command)
        {

            await _commandDispatcher.DispatchAsync(command);
            return Created();
        }

        [HttpGet("{City}")]

        public async Task<ActionResult<LocalizationDTO>> Get([FromRoute] GetLocalizationByCity query)
        {
            var result = await _queryDispatcher.QueryAsync(query);

            return OkOrNotFound(result);
        }
    }
}
