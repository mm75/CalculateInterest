using System.Net.Mime;
using System.Threading.Tasks;
using CalculateInterest.Application.DTO.DTO;
using CalculateInterest.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculateInterest.Compute.API.Controllers
{
    [ApiController]
    [Route("calculajuros")]
    public class ComputeController : ControllerBase
    {
        private readonly IRunService _runService;

        /// <summary>
        /// Method responsible for initializing the controller.
        /// </summary>
        /// <param name="logger">The logger param.</param>
        /// <param name="runService">The service param.</param>
        public ComputeController(ILogger<ComputeController> logger, IRunService runService)
        {
            _runService = runService;
        }

        /// <summary>
        /// Method responsible for the action.
        /// </summary>
        /// <returns>The created <see cref="IActionResult"/> for the response.</returns>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ComputeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ComputeDto>> Get(double initialValue, int time)
        {
            return Ok(await _runService.Run(initialValue, time));
        }
    }
}