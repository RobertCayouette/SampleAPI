using SampleEmployeeAPI.Constants;
using SampleEmployeeAPI.Infrastructure.Interface;
using SampleEmployeeAPI.Model;

namespace SampleEmployeeAPI.Implementation.Class
{
    public class EmployeeService : IEmployeeService
    {
        //public EmployeeService()
        //{
        //}

        public Employee Work(Work employee)
        {
            var employeeObj = EmployeeList.lstEmployee.Find(x => x.Id == employee.Id);

            if (employeeObj == null)
            {
                throw new Exception("Employee does not exist");
            }

            if (employee.WorkDays < 0 || employee.WorkDays > EmployeeConstants.Employee_Workday_Max)
            {
                throw new Exception($"Work days cannot be less than 0 or greater than {EmployeeConstants.Employee_Workday_Max}");
            }

            employeeObj.WorkDays = employee.WorkDays;
            employeeObj.VacationDays = employee.VacationDays;

            return employeeObj;
        }

        public virtual Employee TakeVacation(Vacation employee)
        {
            var employeeObj = EmployeeList.lstEmployee.Find(x => x.Id == employee.Id);

            if (employeeObj == null)
            {
                throw new Exception("Employee does not exist");
            }

            if (employeeObj.VacationDays > EmployeeConstants.Hourly_Employee_Vacation_Max)
            {
                throw new Exception($"Employee cannot take vacations more than {EmployeeConstants.Hourly_Employee_Vacation_Max}");
            }

            if (employeeObj.VacationDays >= employee.VacationDays)
            {
                employeeObj.VacationDays -= employee.VacationDays;
            }

            return employeeObj;
        }
    }
}

/// <summary>
/// This builds the list of employees
/// </summary>
public static class EmployeeList
{
    public static List<Employee> lstEmployee { get; set; } = new List<Employee>();

    public static void ListOfEmployee()
    {

        for (int i = 1; i <= 10; i++)
        {
            lstEmployee.Add(
                new Employee()
                {
                    Id = i,
                    Name = $"Salaried-{i}",
                    EmployeeType = EmployeeType.Salaried,
                    VacationDays = 0,
                    WorkDays = 0
                });
        }

        for (int i = 1; i <= 10; i++)
        {
            lstEmployee.Add(
                new Employee()
                {
                    Id = i,
                    Name = $"Hourly-{i}",
                    EmployeeType = EmployeeType.Hourly,
                    VacationDays = 0,
                    WorkDays = 0
                });
        }

        for (int i = 1; i <= 10; i++)
        {
            lstEmployee.Add(
                new Employee()
                {
                    Id = i,
                    Name = $"Manager-{i}",
                    EmployeeType = EmployeeType.Manager,
                    VacationDays = 0,
                    WorkDays = 0
                });
        }
    }
}
