using WebAppApi.Models;

namespace WebAppApi.EmployeeData
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee? GetEmployee(Guid id);

        void AddEmployee(Employee employee);

        bool DeleteEmployee(Guid id);

        Employee? EditEmployee(Employee employee);
    }
}