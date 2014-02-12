using System.Web.Http;
using mikkark.SCA.Core.Model;

namespace mikkark.SCA.Client.Controllers
{
    public class EmployerDataWebApiController : ApiController
    {
        // GET api/<controller>
        public Employer Get()
        {
            return new Employer {Name = "this comes from the backend"};
        }

        // POST api/<controller>
        public void Post([FromBody] Employer value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}