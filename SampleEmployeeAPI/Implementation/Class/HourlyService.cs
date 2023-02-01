using SampleEmployeeAPI.Constants;
using SampleEmployeeAPI.Model;

namespace SampleEmployeeAPI.Implementation.Class
{
    public class HourlyService : EmployeeService

    {
        //public HourlyService()
        //{
        //}

        public override Employee TakeVacation(Vacation employee)
        {
            var employeeObj = EmployeeList.lstEmployee.Find(x => x.Id == employee.Id);

            if (employeeObj == null)
            {
                throw new Exception("Employee does not exist");
            }

            if (employee.VacationDays > EmployeeConstants.Hourly_Employee_Vacation_Max)
            {
                return employeeObj;
                throw new Exception($"Hourly employees cannot take vacations more than {EmployeeConstants.Hourly_Employee_Vacation_Max}");
            }

            if (employeeObj.VacationDays >= employee.VacationDays)
            {
                employeeObj.VacationDays -= employee.VacationDays;
            }

            return employeeObj;
        }
    }
}
