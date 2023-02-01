using SampleEmployeeAPI.Constants;
using SampleEmployeeAPI.Model;

namespace SampleEmployeeAPI.Implementation.Class
{
    public class SalariedService : EmployeeService
    {
        //public SalariedService()
        //{
        //}

        public override Employee TakeVacation(Vacation employee)
        {
            var employeeObj = EmployeeList.lstEmployee.Find(x => x.Id == employee.Id);

            if (employeeObj == null)
            {
                throw new Exception("Employee does not exist");
            }

            if (employee.VacationDays > EmployeeConstants.Salaried_Employee_Vacation_Max)
            {
                throw new Exception($"Salaried employee cannot take vacations more than {EmployeeConstants.Salaried_Employee_Vacation_Max}");
            }

            if (employeeObj.VacationDays >= employee.VacationDays)
            {
                employeeObj.VacationDays -= employee.VacationDays;
            }

            return employeeObj;
        }
    }
}
