using System;
using System.Linq;
using mikkark.SCA.Core.Model;
using mikkark.SCA.Infra.DomainBaseClasses;
using mikkark.SCA.Persistence.DataModel;

namespace mikkark.SCA.Persistence.Queries
{
    public class GetSalaryCalculationsForAnEmployee : Query<IQueryable<SalaryCalculation>>
    {
        private readonly string _employeeId;
        private readonly BlogdemoSQLEntities _entities;

        public GetSalaryCalculationsForAnEmployee(BlogdemoSQLEntities entities, string employeeId)
        {
            _entities = entities;
            _employeeId = employeeId;
        }

        public override IQueryable<SalaryCalculation> Execute()
        {
            throw new NotImplementedException();
            //return _entities.SalaryCalculations.Where(calc => calc.EmployeeId == _employeeId);
        }
    }
}