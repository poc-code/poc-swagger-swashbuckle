using Microsoft.AspNetCore.Mvc;
using PocSwagger.ViewModel;
using System.Threading.Tasks;

namespace PocSwagger.Controllers
{
    /// <summary>
    /// Reporter
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    [Produces("application/json")]
    [Route("api/v1/reporter")]
    public class ReporterController : ControllerBase
    {
        /// <summary>
        /// Any return
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {

            return Ok("Any Return");
        }

        /// <summary>
        /// Ignore Api
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> PostAsync([FromBody] ValueViewModel request)
        {

            return Ok(request);
        }
    }
}