using Infrastructure.PubSub;

namespace SalarycalculationCore.Events
{
    public class SalaryCalculationFailedEvent : Event
    {
        public SalaryCalculationFailedEvent(string message)
        {
            Message = message;
        }
    }
}