using System.Web.Mvc;

namespace BlogRealm.Web.Areas.AuthorRealm.Controllers
{
    public class AuthController : Controller
    {
        // GET: Author/Auth/Login
        public ActionResult Login()
        {
            return View();
        }
    }
}