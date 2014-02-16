using System;
using System.Collections.ObjectModel;
using System.Web.Http;
using mikkark.SCA.Core.Model;

namespace mikkark.SCA.Client.Controllers
{
    public class EmployerController : ApiController
    {
        // GET api/<controller>
        public Employer Get()
        {
            var emp = new Employer() {Name = "Mikko", Phone = "0403446563"};
            
            emp.Employees = new Collection<Employee>();

            emp.Employees.Add(new Employee() { EmployeeId = Guid.NewGuid().ToString(), Email = "kalle@kalle.com", Name = "Kalle", Phone = "1234567"});
            emp.Employees.Add(new Employee() { EmployeeId = Guid.NewGuid().ToString(), Email = "saana@saana.com", Name = "Saana", Phone = "55422342" });
            emp.Employees.Add(new Employee() { EmployeeId = Guid.NewGuid().ToString(), Email = "ville@ville.com", Name = "Ville", Phone = "21414124" });

            return emp;

            //GetEmployerQuery query = new GetEmployerQuery("foo");
            //return query.Execute();
        }

        public Employer Get(string id)
        {
            return Get();
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