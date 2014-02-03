using System;
using System.Linq;
using Infrastructure.DomainBaseClasses;
using PersistenceLayer.DataModel;
using PersistenceLayer.Queries;
using SalarycalculationCore.Calculation;
using SalarycalculationCore.Events;
using SalarycalculationCore.Model;

namespace PersistenceLayer.Commands
{
    /// <summary>
    ///     This is an example of a state changing command that calls business logic in the core assembly.
    /// </summary>
    /// <remarks>
    ///     Error handling is missing here. The validation might throw exceptions but those should be catched by whoever
    ///     is executing this command, for example an ASP.NET MVC controller base class. This way nobody has to write
    ///     code specifically for catching errors unless there is a business reason to do so. That is one way to make this
    ///     command look really neat and tidy, and now it really captures the happy case scenario.
    /// </remarks>
    public class CalculateSalaryCommand : Command
    {
        private readonly string _employeeId;
        private readonly decimal _grossSalary;
        private readonly DateTime _periodEndDate;
        private readonly DateTime _periodStartDate;
        private readonly BlogdemoSQLEntities db = new BlogdemoSQLEntities();

        public CalculateSalaryCommand(decimal grossSalary, string employeeId, DateTime periodStartDate,
            DateTime periodEndDate)
        {
            _grossSalary = grossSalary;
            _employeeId = employeeId;
            _periodStartDate = periodStartDate;
            _periodEndDate = periodEndDate;
        }

        public override void Execute()
        {
            //The BL is not allowed to run any queries, it can not even reference this assembly containing the
            //queries because that would be a cyclical reference. We need to give all data to the BL.
            IQueryable<SalaryCalculation> previousSalaries =
                QueryRunner.ExecuteQuery(new GetSalaryCalculationsForAnEmployee(db, _employeeId));

            var validation = new SalaryCalculationValidation();
            validation.ValidateSalaryCalculationPreConditions(_periodStartDate, _periodEndDate, previousSalaries);

            string idString = _employeeId;

            Taxcard taxCard = db.Taxcards.SingleOrDefault(card => card.EmployeeId == idString);

            var calculator = new SalaryCalculator();
            SalaryCalculationResults res = calculator.CalculateSalary(taxCard, _grossSalary);

            //Saving the new calculation is not BL, that's why it is here.
            var salaryCalc = new SalaryCalculation
            {
                EmployeeId = _employeeId,
                GrossAmount = _grossSalary,
                NetAmount = res.NetSalary,
                PeriodStartDate = _periodStartDate,
                PeriodEndDate = _periodEndDate,
                Tax = res.Tax,
                SalaryCalculationId = Guid.NewGuid().ToString()
            };
            db.SalaryCalculations.Add(salaryCalc);

            db.SaveChanges();

            //You could argue that sending this event could be BL. Or you can say it is an infrastructural concern, like using
            //a transaction (if that was required here). However, it can not really exist in the salary calculation core because 
            //the core only calculates and the whole process is not done until the result is persisted. So I would say this is
            //the right place after all.
            MessageBus.Send(new SalaryCalculationDoneEvent());
        }
    }
}