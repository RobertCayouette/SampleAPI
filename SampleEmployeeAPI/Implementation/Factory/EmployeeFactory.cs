using SampleEmployeeAPI.Implementation.Class;
using SampleEmployeeAPI.Infrastructure.Interface;

namespace SampleEmployeeAPI.Implementation.Factory
{
    public class EmployeeFactory
    {
        private readonly IServiceProvider serviceProvider;

        public EmployeeFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IEmployeeService? GetEmployeeService(EmployeeType selectedEmployeeType)
        {
            if (selectedEmployeeType == EmployeeType.Salaried)
                return this.serviceProvider.GetService(typeof(SalariedService)) as IEmployeeService;

            if (selectedEmployeeType == EmployeeType.Hourly)
                return this.serviceProvider.GetService(typeof(HourlyService)) as IEmployeeService;

            if (selectedEmployeeType == EmployeeType.Manager)
                return this.serviceProvider.GetService(typeof(ManagersService)) as IEmployeeService;

            return serviceProvider.GetService(typeof(EmployeeService)) as IEmployeeService;
        }
    }
}
