using WebAppApi.Models;

namespace WebAppApi.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
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

        public void AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employees.Add(employee);
        }

        public bool DeleteEmployee(Guid id)
        {
            Employee? employee = GetEmployee(id);

            if (employee == null)
            {
                return false;
            }

            _employees.Remove(employee);
            return true;
        }

        public Employee? EditEmployee(Employee employee)
        {
            int idx = _employees.FindIndex(item => item.Id == employee.Id);

            if (idx == -1)
            {
                return null;
            }

            _employees[idx] = employee;
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