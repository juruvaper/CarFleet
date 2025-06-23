using CarFleetIO.Application.Commands;
using CarFleetIO.Application.DTO;
using CarFleetIO.Application.Queries;
using CarFleetIO.Domain.Entities;
using CarFleetIO.Shared.Abstractions.Commands;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarFleetIO.Api.Controllers
{
    public class carsController : BaseController
    {
    

        public carsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher): base(commandDispatcher, queryDispatcher)
        {
            
        }


        [HttpGet("vin/{vin}")]

        public async Task<ActionResult<CarDTO>> GetByVin([FromRoute] string vin)
        {
            var query = new GetCarByVin { Vin = vin };
            var result = await _queryDispatcher.QueryAsync(query);

            return OkOrNotFound(result);
        }

        [AllowAnonymous]
        [HttpGet("make/{make}")]

        public async Task<ActionResult<ICollection<CarDTO>>> GetByMake([FromRoute] string make)
        {
            var query = new SearchCarByMake { Make = make };
            var result = await _queryDispatcher.QueryAsync(query);

            return OkOrNotFound(result);
        }


        [HttpPost("createcar")]
        public async Task<IActionResult> PostCar([FromBody] CreateCar command)
        {

            await _commandDispatcher.DispatchAsync(command);
            return Created();
        }

        public sealed record SimpleCarDto(Guid Id, string Name);

        /*[HttpGet]
        [AllowAnonymous]
        [ProducesDefaultResponseType(typeof(SimpleCarDto))]

        public async Task<IActionResult> GetAllCars()
        {
            var userId = User.Identity;

            List<SimpleCarDto> cars = new List<SimpleCarDto>();

            for(var i = 0; i < 5; i++)
            {
                var tempCar = new SimpleCarDto(  Guid.NewGuid(), "ABD " + 1  );
                cars.Add(tempCar);
                
            }

            return Ok(cars);
        }*/

        [HttpGet("allcars")]

        public async Task<ActionResult<ICollection<CarDTO>>> GetAllCars()
        {
            var query = new GetAllCars();
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }


    }
}
