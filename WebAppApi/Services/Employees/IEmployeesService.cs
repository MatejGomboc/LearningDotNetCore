using WebAppApi.Models;

namespace WebAppApi.Services.Employees
{
    public interface IEmployeesService
    {
        List<Employee> GetEmployees();

        Employee? GetEmployee(Guid id);

        void AddEmployee(Employee newEmployee);

        bool DeleteEmployee(Guid id);

        Employee? EditEmployee(Employee newEmployee);
    }
}