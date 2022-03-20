using Microsoft.AspNetCore.Mvc;
using WebAppApi.Services.Employees;
using WebAppApi.Models;

namespace WebAppApi.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeesService.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
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
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeesService.AddEmployee(employee);

            return Created(
                HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id,
                employee
            );
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            if (!_employeesService.DeleteEmployee(id))
            {
                return NotFound($"Employee with id {id} was not found.");
            }

            return NoContent();
        }

        [HttpPatch]
        [Route("api/[controller]")]
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