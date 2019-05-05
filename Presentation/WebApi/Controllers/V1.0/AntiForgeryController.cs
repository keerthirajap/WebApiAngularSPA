namespace WebApi.Controllers.V1._0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Antiforgery;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/[controller]")]
    [ApiController]
    public class AntiForgeryController : ControllerBase
    {
        private IAntiforgery _antiForgery;

        public AntiForgeryController(IAntiforgery antiForgery)
        {
            this._antiForgery = antiForgery;
        }

        [HttpGet("api/antiforgery")]
        [IgnoreAntiforgeryToken]
        public IActionResult GenerateAntiForgeryTokens()
        {
            var tokens = this._antiForgery.GetAndStoreTokens(HttpContext);
            Response.Cookies.Append("XSRF-REQUEST-TOKEN", tokens.RequestToken, new Microsoft.AspNetCore.Http.CookieOptions
            {
                HttpOnly = false
            });
            return this.Ok(new { TokeName = "XSRF-REQUEST-TOKEN", RequestToken = tokens.RequestToken });
        }
    }
}