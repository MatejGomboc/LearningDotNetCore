using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi.Models;
using WebAppApi.Services.Employees;

namespace WebAppApi.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetEmployees()
        {
            return Ok(_employeesService.GetEmployees());
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public IActionResult GetEmployee(Guid id)
        {
            Employee? employee = _employeesService.GetEmployee(id);

            if (employee == null)
            {
                return NotFound($"Employee with id {id} was not found.");
            }

            return Ok(employee);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeesService.AddEmployee(employee);

            return Created(
                HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path,
                employee
            );
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteEmployee(Guid id)
        {
            if (!_employeesService.DeleteEmployee(id))
            {
                return NotFound($"Employee with id {id} was not found.");
            }

            return NoContent();
        }

        [HttpPatch]
        [Authorize(Roles = "admin")]
        public IActionResult EditEmployee(Employee employee)
        {
            Employee? newEmployee = _employeesService.EditEmployee(employee);

            if (newEmployee == null)
            {
                return NotFound($"Employee with id {employee.Id} was not found.");
            }

            return Ok(newEmployee);
        }
    }
}