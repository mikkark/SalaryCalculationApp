using System.Web.Mvc;

namespace mikkark.SCA.Client.Controllers
{
    public class SalaryCalculationController : Controller
    {
        //
        // GET: /SalaryCalculation/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}