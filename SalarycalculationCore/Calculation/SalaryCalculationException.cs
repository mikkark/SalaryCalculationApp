using System;

namespace mikkark.SCA.Core.Calculation
{
    public class SalaryCalculationException : Exception
    {
        public SalaryCalculationException(string message) : base(message)
        {
        }
    }
}