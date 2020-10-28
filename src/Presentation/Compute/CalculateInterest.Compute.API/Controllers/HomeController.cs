using Microsoft.AspNetCore.Mvc;

namespace CalculateInterest.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index() => Redirect("/swagger");
    }
}