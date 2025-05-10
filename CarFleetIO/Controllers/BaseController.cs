using CarFleetIO.Shared.Abstractions.Commands;
using CarFleetIO.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CarFleetIO.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public abstract class BaseController: ControllerBase
    {
        protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
        {
            return result is null ? NotFound() : Ok(result);
        }


        protected readonly ICommandDispatcher _commandDispatcher;
        protected readonly IQueryDispatcher _queryDispatcher;

        public BaseController (ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }
    }
}
