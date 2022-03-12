using Microsoft.AspNetCore.Mvc;
using WebAppApi.EmployeeData;
using WebAppApi.Models;

namespace WebAppApi.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;

        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            Employee? employee = _employeeData.GetEmployee(id);

            if (employee == null)
            {
                return NotFound($"Employee with id {id} was not found.");
            }

            return Ok(employee);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);

            return Created(
                HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id,
                employee
            );
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            if (!_employeeData.DeleteEmployee(id))
            {
                return NotFound($"Employee with id {id} was not found.");
            }

            return NoContent();
        }

        [HttpPatch]
        [Route("api/[controller]")]
        public IActionResult EditEmployee(Employee employee)
        {
            Employee? newEmployee = _employeeData.EditEmployee(employee);

            if (newEmployee == null)
            {
                return NotFound($"Employee with id {employee.Id} was not found.");
            }

            return Ok(newEmployee);
        }
    }
}