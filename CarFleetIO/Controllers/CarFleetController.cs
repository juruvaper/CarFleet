using CarFleetIO.Application.Commands;
using CarFleetIO.Application.DTO;
using CarFleetIO.Application.Queries;
using CarFleetIO.Shared.Abstractions.Commands;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CarFleetIO.Api.Controllers
{
    public class CarController : BaseController
    {
    

        public CarController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher): base(commandDispatcher, queryDispatcher)
        {
            
        }


        [HttpGet("{vin}")]

        public async Task<ActionResult<CarDTO>> Get([FromRoute] GetCarByVin query)
        {
            var result = await _queryDispatcher.QueryAsync(query);

            return OkOrNotFound(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCar command)
        {

            await _commandDispatcher.DispatchAsync(command);
            return Created();
        }

     


    } }
