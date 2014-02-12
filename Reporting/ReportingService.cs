using mikkark.SCA.Core.Events;
using mikkark.SCA.Infra.PubSub;

namespace mikkark.SCA.Reporting
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