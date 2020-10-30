using System.Net.Mime;
using CalculateInterest.Application.DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculateInterest.Rate.API.Controllers
{
    [ApiController]
    [Route("taxaJuros")]
    public class RateController : ControllerBase
    {
        /// <summary>
        /// Method responsible for the action.
        /// </summary>
        /// <returns>The created <see cref="IActionResult"/> for the response.</returns>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(RateDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RateDto> Get()
        {
            return Ok(new RateDto {Value = 0.01});
        }
    }
}