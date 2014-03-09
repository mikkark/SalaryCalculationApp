using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using mikkark.SCA.Client.Models;
using mikkark.SCA.Core.Model;
using Newtonsoft.Json.Linq;

namespace mikkark.SCA.Client.Controllers
{
    public class CalculationController : ApiController
    {
        public IList<SalaryCalculation> Get(string id, string statusNotIn)
        {
            var list = new List<SalaryCalculation>();

            list.Add(new SalaryCalculation
            {
                PeriodEndDate = new DateTime(2014, 1, 31),
                PeriodStartDate = new DateTime(2014, 1, 1),
                SalaryCalculationId = Guid.NewGuid().ToString(),
                Status = "GeneratingReports"
            });

            list.Add(new SalaryCalculation
            {
                PeriodEndDate = new DateTime(2014, 1, 21),
                PeriodStartDate = new DateTime(2014, 1, 2),
                SalaryCalculationId = Guid.NewGuid().ToString(),
                Status = "AwaitingApproval"
            });

            return list;
        }

        [HttpPost]
        public string Post(SalaryCalculationViewModel value)
        {
            return HttpStatusCode.OK.ToString();
        }

    }
}