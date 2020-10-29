using System.Net.Mime;
using CalculateInterest.Application.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculateInterest.Rate.API.Controllers
{
    [ApiController]
    [Route("taxaJuros")]
    public class RateController : ControllerBase
    {
        private readonly ILogger<RateController> _logger;

        /// <summary>
        /// Method responsible for initializing the controller.
        /// </summary>
        /// <param name="logger">The logger param.</param>
        public RateController(ILogger<RateController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Method responsible for the action.
        /// </summary>
        /// <returns>The created <see cref="IActionResult"/> for the response.</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public ActionResult<RateDTO> Get()
        {
            return Ok(new RateDTO {Value = 0.01});
        }
    }
}