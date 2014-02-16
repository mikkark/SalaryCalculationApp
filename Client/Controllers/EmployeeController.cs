using System;
using System.Collections.ObjectModel;
using System.Web.Http;
using mikkark.SCA.Core.Model;

namespace mikkark.SCA.Client.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET api/<controller>
        public Employee Get(string id)
        {
            var emp = new Employee() { EmployeeId = id, Name = "Mikko", Phone = "0403446563"};
            
            return emp;

            //GetEmployerQuery query = new GetEmployerQuery("foo");
            //return query.Execute();
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