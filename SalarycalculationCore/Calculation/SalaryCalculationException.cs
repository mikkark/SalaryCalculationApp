using System;

namespace SalarycalculationCore.Calculation
{
    public class SalaryCalculationException : Exception
    {
        public SalaryCalculationException(string message) : base(message)
        {
        }
    }
}