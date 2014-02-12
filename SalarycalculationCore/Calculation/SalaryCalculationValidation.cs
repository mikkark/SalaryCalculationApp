using System;
using System.Linq;
using mikkark.SCA.Core.Model;

namespace mikkark.SCA.Core.Calculation
{
    public class SalaryCalculationValidation
    {
        public void ValidateSalaryCalculationPreConditions(DateTime periodStartDate, DateTime periodEndDate,
            IQueryable<SalaryCalculation> previousSalaries)
        {
            if (previousSalaries.Any(salaryCalculation => salaryCalculation.PeriodStartDate == periodStartDate &&
                                                          salaryCalculation.PeriodEndDate == periodEndDate))
            {
                throw new SalaryCalculationException("Salary calculation exists already for this period");
            }
        }
    }
}