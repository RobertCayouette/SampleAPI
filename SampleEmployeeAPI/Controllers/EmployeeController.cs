using Microsoft.AspNetCore.Mvc;
using SampleEmployeeAPI.Implementation.Factory;
using SampleEmployeeAPI.Model;

namespace SampleEmployeeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeFactory _employeeFactory;

        public EmployeeController(EmployeeFactory employeeFactory)
        {
            _employeeFactory = employeeFactory;
        }

        [HttpPost("Work")]
        [ProducesResponseType(typeof(ServiceResponse<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse<int>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> Work([FromBody] Work employee)
        {
            ServiceResponse<Employee> serviceResponse;
            try
            {  
                var returnEmployee = _employeeFactory.GetEmployeeService(EmployeeType.Default).Work(employee);
                serviceResponse = new ServiceResponse<Employee>()
                {
                    Data = returnEmployee,
                    Message = "Work Update Successfully",
                    Result = true
                };

                return Ok(serviceResponse);
            }
            catch (Exception e)
            {
                serviceResponse = new ServiceResponse<Employee>()
                {
                    Data = EmployeeList.lstEmployee.Find(x => x.Id == employee.Id),
                    Message = e.Message,
                    Result = false
                };

                return BadRequest(serviceResponse);
            }
        }

        [HttpPost("TakeVacation")]
        [ProducesResponseType(typeof(ServiceResponse<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse<Employee>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> TakeVacation([FromBody] Vacation employee)
        {
            ServiceResponse<Employee> serviceResponse;
            try
            {
                serviceResponse = new ServiceResponse<Employee>();
                var returnEmployee = _employeeFactory.GetEmployeeService(employee.EmployeeType).TakeVacation(employee);
                serviceResponse = new ServiceResponse<Employee>()
                {
                    Data = returnEmployee,
                    Message = "Vacation Update Successfully",
                    Result = true
                };

                return Ok(serviceResponse);
            }
            catch (Exception e)
            {
                serviceResponse = new ServiceResponse<Employee>()
                {
                    Data = EmployeeList.lstEmployee.Find(x => x.Id == employee.Id),
                    Message = e.Message,
                    Result = false
                };

                return BadRequest(serviceResponse);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResponse<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse<Employee>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> Index()
        {
            return Ok(EmployeeList.lstEmployee);
        }
    }
}
