using System.Linq;
using Infrastructure.DomainBaseClasses;
using PersistenceLayer.DataModel;
using SalarycalculationCore.Model;

namespace PersistenceLayer.Queries
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
            return _entities.SalaryCalculations.Where(calc => calc.EmployeeId == _employeeId);
        }
    }
}