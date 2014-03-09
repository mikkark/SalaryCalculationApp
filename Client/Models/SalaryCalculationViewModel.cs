using System.Collections.Generic;
using mikkark.SCA.Core.Model;

namespace mikkark.SCA.Client.Models
{
    public class SalaryCalculationViewModel
    {
        public List<Employee> selectedEmployees { get; set; }

        public List<CalculationRow> calculationRows { get; set; }

        public SalaryCalculation salaryCalculation { get; set; }
    }
}