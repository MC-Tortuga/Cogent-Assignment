using Microsoft.AspNetCore.Antiforgery;
using Cogent.Controllers;

namespace Cogent.Web.Host.Controllers
{
    public class AntiForgeryController : CogentControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
