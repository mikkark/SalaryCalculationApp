using System.Web.Mvc;

namespace SalaryCalculationApp.Client.Controllers
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