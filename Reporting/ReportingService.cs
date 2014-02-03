using Infrastructure.PubSub;
using SalarycalculationCore.Events;

namespace Reporting
{
    public class ReportingService
    {
        private static ReportingService _instance;

        /// <summary>
        ///     Default constructor made private because of singleton type behaviour.
        /// </summary>
        private ReportingService()
        {
        }

        public static void Initialize(IMessageBus messagebus)
        {
            _instance = new ReportingService();

            messagebus.Subscribe(typeof (SalaryCalculationDoneEvent), _instance.HandleSuccessfulSalaryCalculation);
        }

        public void HandleSuccessfulSalaryCalculation(Event calculationDone)
        {
            //TODO: Implement creation of report.
        }
    }
}