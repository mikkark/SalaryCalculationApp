using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSPATestRun.Controllers
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