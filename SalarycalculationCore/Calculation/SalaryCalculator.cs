using SalarycalculationCore.Model;

namespace SalarycalculationCore.Calculation
{
    public class SalaryCalculator
    {
        public SalaryCalculationResults CalculateSalary(Taxcard taxCard, decimal grossSalary)
        {
            if (taxCard == null)
            {
                throw new SalaryCalculationException("Salary calculation requires a valid tax card.");
            }

            decimal taxPercentage = taxCard.TaxPercentage;
            decimal tax = grossSalary*(taxPercentage/100);
            decimal netSalary = grossSalary - tax;

            var results = new SalaryCalculationResults();
            results.NetSalary = netSalary;
            results.Tax = tax;

            return results;
        }
    }
}