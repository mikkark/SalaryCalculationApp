using System.Web.Http;
using mikkark.SCA.Core.Model;

namespace mikkark.SCA.Client.Controllers
{
    public class TaxcardController : ApiController
    {
        // GET api/<controller>
        public Taxcard Get(string id)
        {
            var taxcard = new Taxcard {TaxPercentage = 34M, TaxcardId = id};
            return taxcard;

            //GetEmployerQuery query = new GetEmployerQuery("foo");
            //return query.Execute();
        }

        // POST api/<controller>
        public void Post([FromBody] Taxcard value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}