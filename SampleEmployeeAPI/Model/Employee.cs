using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SampleEmployeeAPI.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public float? VacationDays { get; set; }
        public int? WorkDays { get; set; }
    }

    public abstract class abstractEmp
    {
        public int Id { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public float? VacationDays { get; set; }
    }

    public class Work: abstractEmp
    {
        public int? WorkDays { get; set; }
    }

    public class Vacation:abstractEmp
    {
    }
}

public enum EmployeeType
{
    Hourly = 0,
    Salaried = 1,
    Manager = 2,
    Default
}
