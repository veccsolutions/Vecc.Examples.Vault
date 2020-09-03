using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Vecc.Examples.Vault.Controllers
{
    [ApiController]
    [Route("Options")]
    public class OptionsController : Controller
    {
        private readonly IOptions<TestOptions> _options;

        public OptionsController(IOptions<TestOptions> options)
        {
            this._options = options;
        }

        [HttpGet]
        public ActionResult<TestOptions> Get()
        {
            return this._options.Value;
        }
    }
}
