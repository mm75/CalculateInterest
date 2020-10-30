using System.Net.Mime;
using CalculateInterest.Application.DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculateInterest.Compute.API.Controllers
{
    [ApiController]
    [Route("showmethecode")]
    public class ShowMeTheCodeController : ControllerBase
    {
        /// <summary>
        /// Method responsible for the action.
        /// </summary>
        /// <returns>The created <see cref="IActionResult"/> for the response.</returns>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ShowMeTheCodeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ShowMeTheCodeDto> Index()
        {
            return Ok(new ShowMeTheCodeDto {UrlGitHub = "https://github.com/mm75/CalculateInterest"});
        }
    }
}