using mikkark.SCA.Infra.PubSub;

namespace mikkark.SCA.Core.Events
{
    public class SalaryCalculationFailedEvent : Event
    {
        public SalaryCalculationFailedEvent(string message)
        {
            Message = message;
        }
    }
}