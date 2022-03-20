using WebAppApi.Models;

namespace WebAppApi.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeContext _employeeContext;

        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            if (employeeContext.Employees == null)
            {
                throw new ArgumentNullException(nameof(employeeContext.Employees));
            }

            _employeeContext = employeeContext;
        }

        public void AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _employeeContext.Employees.Add(employee);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _employeeContext.SaveChanges();
        }

        public bool DeleteEmployee(Guid id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Employee? existingEmployee = _employeeContext.Employees.Find(id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (existingEmployee == null)
            {
                return false;
            }

            _employeeContext.Employees.Remove(existingEmployee);
            _employeeContext.SaveChanges();
            return true;
        }

        public Employee? EditEmployee(Employee employee)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Employee? existingEmployee = _employeeContext.Employees.Find(employee.Id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.Name = employee.Name;
            _employeeContext.Employees.Update(existingEmployee);
            _employeeContext.SaveChanges();
            return existingEmployee;
        }

        public Employee? GetEmployee(Guid id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return _employeeContext.Employees.Find(id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public List<Employee> GetEmployees()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return _employeeContext.Employees.ToList();
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}