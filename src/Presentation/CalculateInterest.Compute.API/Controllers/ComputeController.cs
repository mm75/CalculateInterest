using System.Net.Mime;
using System.Threading.Tasks;
using CalculateInterest.Application.DTO.DTO;
using CalculateInterest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculateInterest.Compute.API.Controllers
{
    [ApiController]
    [Route("calculajuros")]
    public class ComputeController : ControllerBase
    {
        private readonly ILogger<ComputeController> _logger;
        private readonly IRunService _runService;

        /// <summary>
        /// Method responsible for initializing the controller.
        /// </summary>
        /// <param name="logger">The logger param.</param>
        /// <param name="runService">The service param.</param>
        public ComputeController(ILogger<ComputeController> logger, IRunService runService)
        {
            _logger = logger;
            _runService = runService;
        }

        /// <summary>
        /// Method responsible for the action.
        /// </summary>
        /// <returns>The created <see cref="IActionResult"/> for the response.</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<ComputeDto>> Get(double initialValue, int time)
        {
            _logger.LogInformation($"Realizando o cálculo da taxa de juros.");
            
            return Ok(await _runService.Run(initialValue, time));
        }
    }
}