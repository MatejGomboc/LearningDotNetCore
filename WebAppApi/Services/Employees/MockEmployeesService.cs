using WebAppApi.Models;

namespace WebAppApi.Services.Employees
{
    public class MockEmployeesService : IEmployeesService
    {
        private List<Employee> _employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Employee One"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Employee Two"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Employee Three"
            }
        };

        public void AddEmployee(Employee newEmployee)
        {
            newEmployee.Id = Guid.NewGuid();
            _employees.Add(newEmployee);
        }

        public bool DeleteEmployee(Guid id)
        {
            Employee? existingEmployee = GetEmployee(id);

            if (existingEmployee == null)
            {
                return false;
            }

            _employees.Remove(existingEmployee);
            return true;
        }

        public Employee? EditEmployee(Employee newEmployee)
        {
            int idx = _employees.FindIndex(item => item.Id == newEmployee.Id);

            if (idx == -1)
            {
                return null;
            }

            _employees[idx] = newEmployee;
            return _employees[idx];
        }

        public Employee? GetEmployee(Guid id)
        {
            return _employees.Find(item => item.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}