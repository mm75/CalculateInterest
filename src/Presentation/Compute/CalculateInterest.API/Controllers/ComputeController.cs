using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculateInterest.API.Controllers
{
    [ApiController]
    [Route("calculajuros")]
    public class ComputeController : ControllerBase
    {
        private readonly ILogger<ComputeController> _logger;

        /// <summary>
        /// Method responsible for initializing the controller.
        /// </summary>
        /// <param name="logger">The logger param.</param>
        public ComputeController(ILogger<ComputeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Method responsible for the action.
        /// </summary>
        /// <returns>The created <see cref="IActionResult"/> for the response.</returns>
        /// [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}