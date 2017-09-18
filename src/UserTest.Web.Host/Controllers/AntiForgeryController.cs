using UserTest.Controllers;
using Microsoft.AspNetCore.Antiforgery;

namespace UserTest.Web.Host.Controllers
{
    public class AntiForgeryController : UserTestControllerBase
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