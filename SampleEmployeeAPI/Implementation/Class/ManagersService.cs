using SampleEmployeeAPI.Constants;
using SampleEmployeeAPI.Model;

namespace SampleEmployeeAPI.Implementation.Class
{
    public class ManagersService : EmployeeService
    {
        //public ManagersService()
        //{
        //}

        public override Employee TakeVacation(Vacation employee)
        {
            var employeeObj = EmployeeList.lstEmployee.Find(x => x.Id == employee.Id);

            if (employeeObj == null)
            {
                throw new Exception("Employee does not exist");
            }

            if (employee.VacationDays > EmployeeConstants.Managers_Employee_Vacation_Max)
            {
                return employeeObj;
                throw new Exception($"Managers cannot take vacations more than {EmployeeConstants.Managers_Employee_Vacation_Max}");
            }

            if (employeeObj.VacationDays >= employee.VacationDays)
            {
                employeeObj.VacationDays -= employee.VacationDays;
            }

            return employeeObj;
        }
    }
}
