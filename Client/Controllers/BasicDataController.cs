using System.Web.Mvc;

namespace mikkark.SCA.Client.Controllers
{
    public class BasicDataController : Controller
    {
        //
        // GET: /BasicData/
        [Authorize]
        public ActionResult BasicData()
        {
            return View();
        }
    }
}