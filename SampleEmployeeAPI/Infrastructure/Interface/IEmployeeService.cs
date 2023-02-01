using SampleEmployeeAPI.Model;

namespace SampleEmployeeAPI.Infrastructure.Interface
{
    public interface IEmployeeService
    {
        Employee Work(Work employee);

        Employee TakeVacation(Vacation employee);
    }
}
