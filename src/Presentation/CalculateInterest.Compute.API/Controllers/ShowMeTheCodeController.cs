using System.Net.Mime;
using CalculateInterest.Application.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculateInterest.Compute.API.Controllers
{
    [ApiController]
    [Route("showmethecode")]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly ILogger<ShowMeTheCodeController> _logger;

        public ShowMeTheCodeController(ILogger<ShowMeTheCodeController> logger)
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
        public ActionResult<ShowMeTheCodeDTO> Index()
        {
            return Ok(new ShowMeTheCodeDTO {UrlGitHub = "https://github.com/mm75/CalculateInterest"});
        }
    }
}