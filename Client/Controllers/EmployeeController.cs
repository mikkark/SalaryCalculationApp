using System;
using System.Collections.Generic;
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
            var emp = new Employee {EmployeeId = id, Name = "Mikko", Phone = "0403446563"};

            emp.Taxcards.Add(new Taxcard {TaxcardId = "1", TaxPercentage = 24M});
            emp.Taxcards.Add(new Taxcard {TaxcardId = "2", TaxPercentage = 19M});
            emp.Taxcards.Add(new Taxcard {TaxcardId = "3", TaxPercentage = 30M});

            return emp;

            //GetEmployerQuery query = new GetEmployerQuery("foo");
            //return query.Execute();
        }

        public List<Employee> Get()
        {
            var employees = new List<Employee>();

            employees.Add(new Employee
            {
                EmployeeId = Guid.NewGuid().ToString(),
                Email = "kalle@kalle.com",
                Name = "Kalle",
                Phone = "1234567",
                Taxcards =
                    new Collection<Taxcard> {new Taxcard {TaxcardId = Guid.NewGuid().ToString(), TaxPercentage = 25.0M}}
            });
            employees.Add(new Employee
            {
                EmployeeId = Guid.NewGuid().ToString(),
                Email = "saana@saana.com",
                Name = "Saana",
                Phone = "55422342",
                Taxcards =
                    new Collection<Taxcard> {new Taxcard {TaxcardId = Guid.NewGuid().ToString(), TaxPercentage = 20.0M}}
            });
            employees.Add(new Employee
            {
                EmployeeId = Guid.NewGuid().ToString(),
                Email = "ville@ville.com",
                Name = "Ville",
                Phone = "21414124",
                Taxcards =
                    new Collection<Taxcard> {new Taxcard {TaxcardId = Guid.NewGuid().ToString(), TaxPercentage = 18.5M}}
            });

            return employees;
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